using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;

namespace White.CustomControls.Automation
{
    public class AssemblyBasedFactory
    {
        private readonly Assembly assembly;
        private static readonly Dictionary<string, Assembly> loadedAssemblies = new Dictionary<string, Assembly>();

        public AssemblyBasedFactory(string fileName)
        {
            var fileInfo = new FileInfo(fileName);
            string fullName = fileInfo.FullName;

            if (!loadedAssemblies.ContainsKey(fullName))
            {
                if (!File.Exists(fullName))
                    throw new ConfigurationErrorsException(string.Format("Could not find custom peers assembly. Searched for {0} at {1}", fileName,
                                                                         Environment.CurrentDirectory));
                loadedAssemblies[fullName] = Assembly.Load(File.ReadAllBytes(fullName));
            }
            assembly = loadedAssemblies[fullName];
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