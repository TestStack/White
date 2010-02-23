using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Bricks.Objects;

namespace White.Core.CustomCommands
{
    public class CustomCommandSerializer
    {
        public virtual string SerializeAssembly(string assemblyFile)
        {
            var serializeAssemblyRequest = new object[] { new FileInfo(assemblyFile).Name, File.ReadAllBytes(assemblyFile) };
            var bricksDataContractSerializer = new BricksDataContractSerializer();
            return bricksDataContractSerializer.ToString(serializeAssemblyRequest, new Type[0]);
        }

        public virtual string Serialize(string assemblyName, string typeName, string method, object[] arguments)
        {
            var bricksDataContractSerializer = new BricksDataContractSerializer();
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

        public virtual object[] ToObject(string @string, MethodInfo methodInfo)
        {
            return new BricksDataContractSerializer().ToObject<object[]>(@string, new List<Type> {methodInfo.ReturnType});
        }
    }
}