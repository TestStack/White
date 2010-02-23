namespace White.Core.CustomCommands
{
    public class CustomSilverlightCommandSerializer : ICustomCommandSerializer
    {
        public string ToString(string assemblyFile, string typeName, string methodName, object[] arguments)
        {
            return string.Empty;
        }

        public object ToObject(string @string)
        {

        }
    }
}