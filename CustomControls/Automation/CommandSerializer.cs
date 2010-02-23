using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace White.CustomControls.Automation
{
    public class CommandSerializer : ICommandSerializer
    {
        private readonly CommandAssemblies commandAssemblies;

        public CommandSerializer(CommandAssemblies commandAssemblies)
        {
            this.commandAssemblies = commandAssemblies;
        }

        public virtual ICommand Deserialize(string requestString)
        {
            object request = DeserializeString(requestString);
            var customCommandRequest = new CustomCommandRequest((object[]) request);
            if (customCommandRequest.IsLoadAssemblyCommand)
            {
                return new LoadAssemblyCommand(customCommandRequest.AssemblyName, customCommandRequest.AssemblyContents, commandAssemblies);
            }

            CommandAssembly commandAssembly = commandAssemblies.Get(customCommandRequest.AssemblyName);
            if (commandAssembly == null) return null;
            return new CustomCommand(customCommandRequest.AssemblyName, DeserializeString(customCommandRequest.Payload), new CommandAssemblies());
        }

        private object[] DeserializeString(string @string)
        {
            byte[] requestBytes = Convert.FromBase64String(@string);
            using (var stream = new MemoryStream(requestBytes))
            {
                var dataContractSerializer = new DataContractSerializer(typeof (object[]));
                stream.Position = 0;
                return (object[]) dataContractSerializer.ReadObject(stream);
            }
        }

        public virtual string Serialize(object o, List<Type> knownTypes)
        {
            var stringBuilder = new StringBuilder();
            var xmlWriter = XmlWriter.Create(stringBuilder);

            using (var stream = new MemoryStream())
            {
                var dataContractSerializer = new DataContractSerializer(o.GetType(), knownTypes);
                dataContractSerializer.WriteObject(stream, o); 
                stream.Position = 0;
                byte[] bytes = stream.ToArray();
                return Convert.ToBase64String(bytes);
            }
        }
    }
}