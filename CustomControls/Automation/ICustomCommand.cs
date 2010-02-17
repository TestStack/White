namespace White.CustomControls.Automation
{
    public interface ICustomCommand
    {
        string MethodName { get; }
        object[] Arguments { get; }
        string TypeName { get; }
        string AssemblyFile { get; }
        string GetImplementedTypeName();
    }
}