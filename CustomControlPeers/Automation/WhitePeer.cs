using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;

namespace White.CustomControls.Peers.Automation
{
    public class WhitePeer
    {
        private readonly object automationPeer;
        private readonly object control;
        private readonly ICommandSerializer commandSerializer;
        private readonly GetValueDelegate getValueDelegate;
        private readonly SetValueDelegate setValueDelegate;
        private object value;
        private bool customCommandSessionOpen;

        public delegate string GetValueDelegate();

        public delegate void SetValueDelegate(string value);

        public static WhitePeer Create(object automationPeer, object control)
        {
            return CreateForValueProvider(automationPeer, control, null, null);
        }

        public static WhitePeer CreateForValueProvider(object automationPeer, object control, GetValueDelegate getValueDelegate,
                                                       SetValueDelegate setValueDelegate)
        {
            return new WhitePeer(automationPeer, control, new CommandSerializer(new CommandAssemblies()), getValueDelegate, setValueDelegate);
        }

        private WhitePeer(object automationPeer, object control, ICommandSerializer commandSerializer, GetValueDelegate getValueDelegate,
                          SetValueDelegate setValueDelegate)
        {
            
            if (!(automationPeer is IValueProvider)) throw new ArgumentException("Automation Peer should be a IValueProvider");

            this.automationPeer = automationPeer;
            this.control = control;
            this.commandSerializer = commandSerializer;
            this.getValueDelegate = getValueDelegate;
            this.setValueDelegate = setValueDelegate;
        }

        public virtual void SetValue(string commandString)
        {
            try
            {
                ICommand command;
                customCommandSessionOpen = commandSerializer.TryDeserialize(commandString, out command);
                if (customCommandSessionOpen && command is EndSessionCommand)
                {
                    customCommandSessionOpen = false;
                }
                else if (customCommandSessionOpen)
                {
                    value = command == null ? new object[2] : new[] {command.Execute(control)};
                }
                else
                {
                    setValueDelegate(commandString);
                }
            }
            catch (Exception e)
            {
                value = new object[] {e.ToString(), null};
            }
        }

        public virtual string Value
        {
            get
            {
                try
                {
                    if (!customCommandSessionOpen) return getValueDelegate();

                    if (value == null) return null;
                    var response = ((object[]) value);
                    object commandReturnValue = response[0];
                    List<Type> knownTypes = commandReturnValue == null ? new List<Type>() : new List<Type> {commandReturnValue.GetType()};
                    return commandSerializer.Serialize(response, knownTypes);
                }
                catch (Exception e)
                {
                    return commandSerializer.Serialize(e, new List<Type>());
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