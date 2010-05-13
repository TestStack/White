using System.Windows.Automation.Peers;
using System.Windows.Controls;
using White.CustomControls.Peers;

namespace White.CustomControls
{
    public class WhiteMenuItem : MenuItem
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteMenuItemPeer(this);
        }
    }
}