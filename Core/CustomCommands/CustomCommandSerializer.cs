using System;
using System.Collections.Generic;
using Bricks.Objects;

namespace White.Core.CustomCommands
{
    public class CustomCommandSerializer : ICustomCommandSerializer
    {
        public virtual string ToString(string assemblyFile, string typeName, string methodName, object[] @arguments)
        {
            var list = new List<object> { typeName, methodName, @arguments };
            byte[] payloadBytes = BricksBinaryFormatter.ToByteArray(list);
            var request = new object[] {assemblyFile, payloadBytes};
            byte[] requestBytes = BricksBinaryFormatter.ToByteArray(request);
            return Convert.ToBase64String(requestBytes);
        }

        public virtual object ToObject(string @string)
        {
            byte[] bytes = Convert.FromBase64String(@string);
            return BricksBinaryFormatter.ToObject(bytes);
        }
    }
}