using System.Windows.Automation.Peers;
using System.Windows.Controls;
using White.CustomControls.WPF.Peers;
using White.CustomControls.Automation;

namespace White.CustomControls.WPF
{
    public class WhiteButton : Button
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteWPFButtonPeer(this, new CustomCommandDeserializer());
        }
    }
}