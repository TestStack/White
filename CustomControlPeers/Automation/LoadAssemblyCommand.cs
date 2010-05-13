



namespace White.CustomControls.Peers.Automation
{
    public class LoadAssemblyCommand : ICommand
    {
        private readonly string assemblyName;
        private readonly byte[] contents;
        private readonly CommandAssemblies commandAssemblies;

        public LoadAssemblyCommand(string assemblyName, byte[] contents, CommandAssemblies commandAssemblies)
        {
            this.assemblyName = assemblyName;
            this.contents = contents;
            this.commandAssemblies = commandAssemblies;
        }

        public virtual object Execute(object control)
        {
            commandAssemblies.Add(assemblyName, contents);
            return null;
        }
    }
}