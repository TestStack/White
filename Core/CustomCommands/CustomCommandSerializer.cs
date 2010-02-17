using System;
using System.Collections.Generic;
using Bricks.Objects;

namespace White.Core.CustomCommands
{
    public static class CustomCommandSerializer
    {
        public static string ToString(string assemblyFile, string typeName, string methodName, object[] @arguments)
        {
            var list = new List<object> { assemblyFile, typeName, methodName, @arguments };
            return Convert.ToBase64String(BricksBinaryFormatter.ToByteArray(list));
        }

        public static object ToObject(string @string)
        {
            byte[] bytes = Convert.FromBase64String(@string);
            return BricksBinaryFormatter.ToObject(bytes);
        }
    }
}