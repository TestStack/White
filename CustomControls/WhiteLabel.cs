using System.Windows.Automation.Peers;
using System.Windows.Controls;
using White.CustomControls.Peers;

namespace White.CustomControls
{
    public class WhiteLabel : Label
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteLabelPeer(this);
        }
    }
}