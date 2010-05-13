using System.Windows.Automation.Peers;
using System.Windows.Controls;
using White.CustomControls.Peers;

namespace White.CustomControls
{
    public class WhiteContextMenu : ContextMenu
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteContextMenuPeer(this);
        }
    }
}