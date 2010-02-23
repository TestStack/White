using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using White.CustomControls.Automation;

namespace CustomControls.Silverlight.Peers
{
    public class WhiteButtonPeer : ButtonAutomationPeer, IValueProvider
    {
        private readonly WhitePeer whitePeer;

        public WhiteButtonPeer(Button button) : base(button)
        {
            whitePeer = WhitePeer.Create(this, button);
        }

        public void SetValue(string commandString)
        {
            whitePeer.SetValue(commandString);
        }

        public string Value
        {
            get { return whitePeer.Value; }
        }

        public bool IsReadOnly
        {
            get { return whitePeer.IsReadOnly; }
        }

        public override object GetPattern(PatternInterface patternInterface)
        {
            return whitePeer.GetPattern(patternInterface);
        }
    }
}