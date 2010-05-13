using System.Collections.Generic;
using System.Reflection;

namespace White.CustomControls.Automation
{
    public class CommandAssemblies
    {
        private static readonly Dictionary<string, CommandAssembly> list = new Dictionary<string, CommandAssembly>();

        public virtual CommandAssembly Add(string name, byte[] contents)
        {
            if (!list.ContainsKey(name))
            {
                list[name] = new CommandAssembly(Assembly.Load(contents));
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