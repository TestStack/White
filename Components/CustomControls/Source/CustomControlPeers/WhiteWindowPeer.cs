using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using White.CustomControls.Peers.Automation;

namespace White.CustomControls.Peers
{
    public class WhiteWindowPeer : WindowAutomationPeer, IValueProvider
    {
        private readonly WhitePeer whitePeer;

        public WhiteWindowPeer(Window owner) : base(owner)
        {
            whitePeer = WhitePeer.Create(this, owner);
        }

        public virtual void SetValue(string commandString)
        {
            whitePeer.SetValue(commandString);
        }

        public virtual string Value
        {
            get { return whitePeer.Value; }
        }

        public virtual bool IsReadOnly
        {
            get { return whitePeer.IsReadOnly; }
        }

        public override object GetPattern(PatternInterface patternInterface)
        {
            return whitePeer.GetPattern(patternInterface);
        }
    }
}