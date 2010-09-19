using System.Windows.Automation.Peers;
using System.Windows.Controls;
using White.CustomControls.Peers;

namespace White.CustomControls
{
    public class WhiteTextBox : TextBox
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteTextBoxPeer(this);
        }
    }
}