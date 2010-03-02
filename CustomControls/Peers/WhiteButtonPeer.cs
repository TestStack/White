using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using White.CustomControls.Automation;

namespace White.CustomControls.Peers
{
    public class WhiteButtonPeer : ButtonAutomationPeer, IValueProvider
    {
        private readonly WhitePeer whitePeer;

        public WhiteButtonPeer(Button button) : base(button)
        {
            whitePeer = WhitePeer.Create(this, button);
        }

        public override object GetPattern(PatternInterface patternInterface)
        {
            return whitePeer.GetPattern(patternInterface);
        }

        public virtual void SetValue(string command)
        {
            whitePeer.SetValue(command);
        }

        public virtual string Value
        {
            get { return whitePeer.Value; }
        }

        public virtual bool IsReadOnly
        {
            get { return whitePeer.IsReadOnly; }
        }
    }
}