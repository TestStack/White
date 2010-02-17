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
                loadedAssemblies[fullName] = Assembly.LoadFile(fullName);
            }
            assembly = loadedAssemblies[fullName];
        }

//
//        public virtual object CreateBasedOn(Type attributeType)
//        {
//            object[] peerRepositoryAttributes = assembly.GetCustomAttributes(attributeType, false);
//            if (peerRepositoryAttributes.Length == 0)
//                throw new ConfigurationErrorsException(string.Format("No PeerRepositoryAttribute defined in {0}", assembly.FullName));
//
//            var peerRepositoryAttribute = (PeerRepositoryAttribute) peerRepositoryAttributes[0];
//            Type type = peerRepositoryAttribute.PeerFactory;
//            return Create(type);
//        }

        public virtual object Create(string typeName, params object[] arguments)
        {
            try
            {
                Type type = assembly.GetType(typeName);
                ConstructorInfo[] constructors = type.GetConstructors();
                ConstructorInfo constructorInfo = constructors.FirstOrDefault(info => info.GetParameters().Length == arguments.Length);
                return constructorInfo.Invoke(arguments);
            }
            catch (ArgumentException argumentException)
            {
                throw new ArgumentException(string.Format("Could not matching constructor, {0}", GetTypeNames(arguments)), argumentException);
            }
        }

        private static string GetTypeNames(object[] arguments)
        {
            if (arguments == null || arguments.Length == 0) return "VOID";
            return string.Join(",", arguments.Select(o => o.GetType().ToString()).ToArray());
        }
    }
}