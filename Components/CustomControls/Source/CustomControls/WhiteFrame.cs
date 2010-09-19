using System.Windows.Automation.Peers;
using System.Windows.Controls;
using White.CustomControls.Peers;

namespace White.CustomControls
{
    public class WhiteFrame : Frame
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteFramePeer(this);
        }
    }
}