using System.Windows.Automation.Peers;
using System.Windows.Controls;
using CustomControls.Silverlight.Peers;

namespace CustomControls.Silverlight
{
    public class WhiteComboBox : ComboBox
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteComboBoxPeer(this);
        }
    }
}