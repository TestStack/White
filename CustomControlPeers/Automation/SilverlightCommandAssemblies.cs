using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;

namespace White.CustomControls.Peers.Automation
{
    public class CommandAssemblies : ICommandAssemblies
    {
        private static readonly Dictionary<string, CommandAssembly> list = new Dictionary<string, CommandAssembly>();

        public virtual ICommandAssembly Add(string name, byte[] contents, IKnownTypeHolder knownTypeHolder)
        {
            if (!list.ContainsKey(name))
            {
                using (var memoryStream = new MemoryStream(contents))
                {
                    var part = new AssemblyPart();
                    Assembly assembly = part.Load(memoryStream);
                    list[name] = new CommandAssembly(assembly, knownTypeHolder);
                }
            }
            return list[name];
        }

        public virtual ICommandAssembly Get(string assemblyName)
        {
            if (list.ContainsKey(assemblyName)) return list[assemblyName];
            return null;
        }
    }
}