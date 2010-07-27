using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace White.CustomControls.Peers.Automation
{
    public class CommandSerializer : ICommandSerializer, IKnownTypeHolder
    {
        private readonly ICommandAssemblies commandAssemblies;

        private static readonly List<Type> exceptions = new List<Type> { typeof(XmlException), typeof(FormatException), typeof(SerializationException) };
        private static readonly List<Type> knownTypes = new List<Type>
                                                                    {
                                                                        typeof (object[]),
                                                                        typeof (string[]),
                                                                        typeof (int[]),
                                                                        typeof (double[]),
                                                                        typeof (DateTime[]),
                                                                        typeof (Exception)
                                                                    };

        public CommandSerializer(ICommandAssemblies commandAssemblies)
        {
            this.commandAssemblies = commandAssemblies;
        }

        public virtual bool TryDeserializeCommand(string requestString, out ICommand command)
        {
            object[] request;
            if (!TryDeserializeString(requestString, out request))
            {
                command = null;
                return false;
            }

            var customCommandRequest = new CustomCommandRequest(request);
            if (customCommandRequest.IsLoadAssemblyCommand)
            {
                command = new LoadAssemblyCommand(customCommandRequest.AssemblyName, customCommandRequest.AssemblyContents, commandAssemblies, this);
            }
            else if (customCommandRequest.IsEndSessionCommand)
            {
                command = new EndSessionCommand();
            }
            else
            {
                ICommandAssembly commandAssembly = commandAssemblies.Get(customCommandRequest.AssemblyName);
                command = commandAssembly == null
                              ? null
                              : new CustomCommand(customCommandRequest.AssemblyName, DeserializeString(customCommandRequest.Payload), new CommandAssemblies());
            }
            return true;
        }

        private bool TryDeserializeString(string @string, out object[] objects)
        {
            try
            {
                objects = DeserializeString(@string);
                return true;
            }
            catch (Exception e)
            {
                if (exceptions.Contains(e.GetType()))
                {
                    objects = null;
                    return false;
                }
                throw;
            }
        }

        private object[] DeserializeString(string @string)
        {
            byte[] requestBytes = Convert.FromBase64String(@string);
            using (var stream = new MemoryStream(requestBytes))
            {
                var dataContractSerializer = new DataContractSerializer(typeof(object[]), knownTypes);
                stream.Position = 0;
                return (object[]) dataContractSerializer.ReadObject(stream);
            }
        }

        public virtual string Serialize(object o, IEnumerable<Type> knownTypes)
        {
            using (var stream = new MemoryStream())
            {
                var dataContractSerializer = new DataContractSerializer(o.GetType(), knownTypes);
                dataContractSerializer.WriteObject(stream, o);
                stream.Position = 0;
                byte[] bytes = stream.ToArray();
                return Convert.ToBase64String(bytes);
            }
        }

        public void Add(Type type)
        {
            knownTypes.Add(type);
            knownTypes.Add(type.MakeArrayType());
        }
    }
}