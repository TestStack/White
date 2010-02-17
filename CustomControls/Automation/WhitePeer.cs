using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Automation.Peers;
using System.Windows.Controls;

namespace White.WPFCustomControls.Automation
{
    public class WhitePeer
    {
        private readonly AutomationPeer automationPeer;
        private readonly object control;
        private readonly ICustomCommandDeserializer customCommandDeserializer;
        private object value;

        public WhitePeer(AutomationPeer automationPeer, Control control, ICustomCommandDeserializer customCommandDeserializer)
        {
            this.automationPeer = automationPeer;
            this.control = control;
            this.customCommandDeserializer = customCommandDeserializer;
        }

        public virtual string Value
        {
            get
            {
                try
                {
                    return ToString(value);
                }
                catch (Exception e)
                {
                    return ToString(e);
                }
            }
        }

        private string ToString(object @object)
        {
            using (var memoryStream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, @object);
                memoryStream.Position = 0;
                byte[] bytes = memoryStream.ToArray();
                return Convert.ToBase64String(bytes);
            }
        }

        public virtual object GetPattern(PatternInterface patternInterface)
        {
            if (patternInterface == PatternInterface.Value) return automationPeer;
            return null;
        }

        public virtual void SetValue(string commandString)
        {
            try
            {
                ICustomCommand customCommand = customCommandDeserializer.GetCommand(commandString);
                var factory = new AssemblyBasedFactory(customCommand.AssemblyFile);
                object commandImpl = factory.Create(customCommand.GetImplementedTypeName(), control);
                MethodInfo methodInfo = commandImpl.GetType().GetMethod(customCommand.MethodName);
                value = methodInfo.Invoke(commandImpl, customCommand.Arguments);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}