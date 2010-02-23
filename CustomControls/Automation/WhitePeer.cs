using System;
using System.Collections.Generic;
using System.Windows.Automation.Peers;
using System.Windows.Controls;

namespace White.CustomControls.Automation
{
    public class WhitePeer
    {
        private readonly AutomationPeer automationPeer;
        private readonly object control;
        private readonly ICommandSerializer commandSerializer;
        private readonly GetValue getValue;
        private object value;

        public delegate string GetValue();

        public static WhitePeer Create(AutomationPeer automationPeer, Control control)
        {
            return CreateForValueProvider(automationPeer, control, null);
        }

        public static WhitePeer CreateForValueProvider(AutomationPeer automationPeer, Control control, GetValue getValue)
        {
            return new WhitePeer(automationPeer, control, new CommandSerializer(new CommandAssemblies()), getValue);
        }

        private WhitePeer(AutomationPeer automationPeer, Control control, ICommandSerializer commandDeserializer, GetValue getValue)
        {
            this.automationPeer = automationPeer;
            this.control = control;
            commandSerializer = commandDeserializer;
            this.getValue = getValue;
        }

        public virtual void SetValue(string commandString)
        {
            try
            {
                value = null;
                ICommand command = commandSerializer.Deserialize(commandString);
                value = command == null ? new object[2] : new[] {command.Execute(control)};
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public virtual string Value
        {
            get
            {
                try
                {
                    if (value == null)
                    {
                        return getValue();
                    }
                    var response = ((object[]) value);
                    object commandReturnValue = response[0];
                    List<Type> knownTypes = commandReturnValue == null ? new List<Type>() : new List<Type> {commandReturnValue.GetType()};
                    return commandSerializer.Serialize(response, knownTypes);
                }
                catch (Exception e)
                {
                    return commandSerializer.Serialize(e, new List<Type>());
                }
                finally
                {
                    value = null;
                }
            }
        }

        public virtual bool IsReadOnly
        {
            get { return false; }
        }

        public virtual object GetPattern(PatternInterface patternInterface)
        {
            if (patternInterface == PatternInterface.Value) return automationPeer;
            return null;
        }
    }
}