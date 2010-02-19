using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace White.CustomControls.Automation
{
    public class CustomCommandDeserializer : ICustomCommandDeserializer
    {
        public virtual ICustomCommand GetCommand(string requestString)
        {
            byte[] requestBytes = Convert.FromBase64String(requestString);
            var request = (object[]) Deserialize(requestBytes);
            var assemblyFile = (string) request[0];
            return new CustomCommand(assemblyFile, (List<object>) Deserialize((byte[]) request[1]));
        }

        private static object Deserialize(byte[] bytes)
        {
            using (var stream = new MemoryStream(bytes))
            {
                return new BinaryFormatter().Deserialize(stream);
            }
        }
    }
}