using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace White.CustomControls.Peers.Automation
{
    public interface ICommandAssembly
    {
        object Create(string typeName, params object[] arguments);
        Type GetType(Type type);
    }

    public class CommandAssembly : ICommandAssembly
    {
        private readonly Assembly assembly;

        public CommandAssembly(Assembly assembly, IKnownTypeHolder knownTypeHolder)
        {
            this.assembly = assembly;
            var types = assembly.GetTypes();
            foreach (Type type in types)
            {
                if (type.IsInterface || type.GetCustomAttributes(typeof(DataContractAttribute), false).Length != 1) continue;
                knownTypeHolder.Add(type);
            }
        }

        public virtual object Create(string typeName, params object[] arguments)
        {
            try
            {
                Type type = GetType(typeName);
                ConstructorInfo[] constructors = type.GetConstructors();
                ConstructorInfo constructorInfo = constructors.FirstOrDefault(info => info.GetParameters().Length == arguments.Length);
                return constructorInfo.Invoke(arguments);
            }
            catch (ArgumentException argumentException)
            {
                throw new ArgumentException(string.Format("Could not matching constructor, {0}", GetTypeNames(arguments)), argumentException);
            }
        }

        public virtual Type GetType(Type type)
        {
            return GetType(type.FullName);
        }

        private Type GetType(string typeFullName)
        {
            return assembly.GetType(typeFullName);
        }

        private static string GetTypeNames(object[] arguments)
        {
            if (arguments == null || arguments.Length == 0) return "VOID";
            return string.Join(",", arguments.Select(o => o.GetType().ToString()).ToArray());
        }
    }
}