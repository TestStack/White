using System.Windows.Automation.Peers;
using System.Windows.Controls;
using White.CustomControls.Peers;

namespace White.CustomControls
{
    public class WhiteButton : Button
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteButtonPeer(this);
        }
    }
}