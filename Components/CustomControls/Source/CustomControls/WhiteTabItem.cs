using System.Windows.Automation.Peers;
using System.Windows.Controls;
using White.CustomControls.Peers;

namespace White.CustomControls
{
    public class WhiteTabItem : TabItem
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteTabItemPeer(this);
        }
    }
}