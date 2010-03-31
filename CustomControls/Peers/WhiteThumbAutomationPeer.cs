using System.Windows.Automation.Peers;
using System.Windows.Controls.Primitives;
using White.CustomControls.Automation;

namespace White.CustomControls.Peers
{
    public class WhiteThumbAutomationPeer : ThumbAutomationPeer
    {
        private readonly WhitePeer whitePeer;

        public WhiteThumbAutomationPeer(Thumb owner) : base(owner)
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