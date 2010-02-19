namespace White.CustomControls.Automation
{
    public interface ICustomCommand
    {
        string MethodName { get; }
        object[] GetArguments(AssemblyBasedFactory factory);
        string TypeName { get; }
        string AssemblyFile { get; }
        string GetImplementedTypeName();
    }
}