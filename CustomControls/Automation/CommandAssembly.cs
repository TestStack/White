using System;
using System.Linq;
using System.Reflection;

namespace White.CustomControls.Automation
{
    public class CommandAssembly
    {
        private readonly Assembly assembly;

        public CommandAssembly(Assembly assembly)
        {
            this.assembly = assembly;
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

        public virtual Type GetType(string typeName)
        {
            return assembly.GetType(typeName);
        }

        private static string GetTypeNames(object[] arguments)
        {
            if (arguments == null || arguments.Length == 0) return "VOID";
            return string.Join(",", arguments.Select(o => o.GetType().ToString()).ToArray());
        }
    }
}