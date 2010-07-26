namespace White.CustomControls.Peers.Automation
{
    public interface ICommandAssemblies
    {
        ICommandAssembly Add(string name, byte[] contents, IKnownTypeHolder knownTypeHolder);
        ICommandAssembly Get(string assemblyName);
    }
}