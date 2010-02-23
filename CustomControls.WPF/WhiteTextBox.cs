using System.Windows.Automation.Peers;
using System.Windows.Controls;
using White.CustomControls.WPF.Peers;

namespace White.CustomControls.WPF
{
    public class WhiteTextBox : TextBox
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteTextBoxPeer(this);
        }
    }
}