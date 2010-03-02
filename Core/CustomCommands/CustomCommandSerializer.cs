using System;
using System.Collections.Generic;
using System.IO;
using Bricks.Objects;

namespace White.Core.CustomCommands
{
    public class CustomCommandSerializer
    {
        private readonly BricksDataContractSerializer bricksDataContractSerializer = new BricksDataContractSerializer();

        public virtual string SerializeAssembly(string assemblyFile)
        {
            var serializeAssemblyRequest = new object[] {new FileInfo(assemblyFile).Name, File.ReadAllBytes(assemblyFile)};
            return bricksDataContractSerializer.ToString(serializeAssemblyRequest, new Type[0]);
        }

        public virtual string Serialize(string assemblyName, string typeName, string method, object[] arguments)
        {
            var knownTypes = new List<Type> {typeof (object[])};
            foreach (var argument in arguments)
            {
                if (argument != null && !knownTypes.Contains(argument.GetType())) knownTypes.Add(argument.GetType());
            }
            var commandList = new object[] {typeName, method, @arguments};
            string payload = bricksDataContractSerializer.ToString(commandList, knownTypes);

            var request = new object[] {assemblyName, payload};
            return bricksDataContractSerializer.ToString(request, knownTypes);
        }

        public virtual object[] ToObject(string @string, Type returnType)
        {
            return bricksDataContractSerializer.ToObject<object[]>(@string, new List<Type> {returnType});
        }

        public virtual string SerializeEndSession()
        {
            return bricksDataContractSerializer.ToString(new object[0], new Type[0]);
        }
    }
}