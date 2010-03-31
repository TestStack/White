using System.Windows.Automation.Peers;
using System.Windows.Controls;
using White.CustomControls.Automation;

namespace White.CustomControls.Peers
{
    public class WhiteTreeViewAutomationPeer : TreeViewAutomationPeer
    {
        private readonly WhitePeer whitePeer;

        public WhiteTreeViewAutomationPeer(TreeView owner) : base(owner)
        {
            whitePeer = WhitePeer.Create(this, owner);
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