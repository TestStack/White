using System.Windows.Automation.Peers;
using System.Windows.Controls;
using CustomControls.Silverlight.Peers;

namespace CustomControls.Silverlight
{
    public class WhiteButton : Button
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteButtonPeer(this);
        }
    }
}