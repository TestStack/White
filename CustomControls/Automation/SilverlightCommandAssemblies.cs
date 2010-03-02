using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;

namespace White.CustomControls.Automation
{
    public class CommandAssemblies
    {
        private static readonly Dictionary<string, CommandAssembly> list = new Dictionary<string, CommandAssembly>();

        public virtual CommandAssembly Add(string name, byte[] contents)
        {
            if (!list.ContainsKey(name))
            {
                using (var memoryStream = new MemoryStream(contents))
                {
                    var part = new AssemblyPart();
                    Assembly assembly = part.Load(memoryStream);
                    list[name] = new CommandAssembly(assembly);
                }
            }
            return list[name];
        }

        public virtual CommandAssembly Get(string assemblyName)
        {
            if (list.ContainsKey(assemblyName)) return list[assemblyName];
            return null;
        }
    }
}