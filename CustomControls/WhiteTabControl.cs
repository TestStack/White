using System.Windows.Automation.Peers;
using System.Windows.Controls;
using White.CustomControls.Peers;

namespace White.CustomControls
{
    public class WhiteTabControl : TabControl
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteTabControlPeer(this);
        }
    }
}