using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Automation.Peers;
using System.Windows.Controls;

namespace White.CustomControls.Automation
{
    public class WhitePeer
    {
        private readonly AutomationPeer automationPeer;
        private readonly object control;
        private readonly ICustomCommandDeserializer customCommandDeserializer;
        private object value;

        public WhitePeer(AutomationPeer automationPeer, Control control)
        {
            this.automationPeer = automationPeer;
            this.control = control;
            customCommandDeserializer = new CustomCommandDeserializer();
        }

        public virtual string Value
        {
            get
            {
                try
                {
                    if (value == null) return null;
                    return ToString(value);
                }
                catch (Exception e)
                {
                    return ToString(e);
                }
            }
        }

        public virtual bool IsReadOnly
        {
            get { return false; }
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
                value = null;
                ICustomCommand customCommand = customCommandDeserializer.GetCommand(commandString);
                var factory = new AssemblyBasedFactory(customCommand.AssemblyFile);
                object commandImpl = factory.Create(customCommand.GetImplementedTypeName(), control);
                MethodInfo methodInfo = commandImpl.GetType().GetMethod(customCommand.MethodName);
                value = methodInfo.Invoke(commandImpl, customCommand.GetArguments(factory));
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}