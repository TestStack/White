using System.Windows.Automation.Peers;
using System.Windows.Controls;
using White.CustomControls.Peers;

namespace White.CustomControls
{
    public class WhiteToolTip : ToolTip
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteToolTipPeer(this);
        }
    }
}