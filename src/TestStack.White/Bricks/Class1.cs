using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace White.Core.Bricks
{
    public class BricksDataContractSerializer
    {
        public virtual string ToString(object @object, IEnumerable<Type> knownTypes)
        {
            using (var stream = new MemoryStream())
            {
                var dataContractSerializer = new DataContractSerializer(@object.GetType(), knownTypes);
                dataContractSerializer.WriteObject(stream, @object);
                stream.Position = 0;
                byte[] bytes = stream.ToArray();
                return Convert.ToBase64String(bytes);
            }
        }

        public virtual T ToObject<T>(string @string, IEnumerable<Type> knownTypes)
        {
            if (string.IsNullOrEmpty(@string)) return default(T);

            var bytes = Convert.FromBase64String(@string);
            using (var stream = new MemoryStream(bytes))
            {
                var dataContractSerializer = new DataContractSerializer(typeof(T), knownTypes);
                stream.Position = 0;
                return (T)dataContractSerializer.ReadObject(stream);
            }
        }
    }

}