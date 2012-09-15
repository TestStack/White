using System.Windows.Automation.Peers;
using System.Windows.Controls;
using White.CustomControls.Peers;

namespace White.CustomControls
{
    public class WhiteRadioButton : RadioButton
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteRadioButtonPeer(this);
        }
    }
}