using System.Windows.Automation.Peers;
using System.Windows.Controls;
using White.CustomControls.Peers;

namespace White.CustomControls
{
    public class WhiteMenu : Menu
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteMenuPeer(this);
        }
    }
}