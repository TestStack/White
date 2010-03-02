using System.Windows.Automation.Peers;
using System.Windows.Controls;
using White.CustomControls.Peers;

namespace White.CustomControls
{
    public class WhiteComboBox : ComboBox
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteComboBoxPeer(this);
        }
    }
}