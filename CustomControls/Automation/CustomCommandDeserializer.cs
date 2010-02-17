using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace White.CustomControls.Automation
{
    public class CustomCommandDeserializer : ICustomCommandDeserializer
    {
        public virtual ICustomCommand GetCommand(string s)
        {
            byte[] bytes = Convert.FromBase64String(s);
            using (var stream = new MemoryStream(bytes))
            {
                var dictionary = new BinaryFormatter().Deserialize(stream);
                return new CustomCommand((List<object>) dictionary);
            }
        }
    }
}