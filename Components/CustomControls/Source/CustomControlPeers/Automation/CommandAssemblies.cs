using System.Collections.Generic;
using System.Reflection;

namespace White.CustomControls.Peers.Automation
{
    public class CommandAssemblies : ICommandAssemblies
    {
        private static readonly Dictionary<string, CommandAssembly> list = new Dictionary<string, CommandAssembly>();

        public virtual ICommandAssembly Add(string name, byte[] contents, IKnownTypeHolder knownTypeHolder)
        {
            if (!list.ContainsKey(name))
            {
                list[name] = new CommandAssembly(Assembly.Load(contents), knownTypeHolder);
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