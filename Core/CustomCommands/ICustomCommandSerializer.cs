namespace White.Core.CustomCommands
{
    public interface ICustomCommandSerializer
    {
        string ToString(string assemblyFile, string typeName, string methodName, object[] @arguments);
        object ToObject(string @string);
    }
}