using System.Windows.Automation.Peers;
using System.Windows.Controls.Primitives;
using White.CustomControls.Peers;

namespace White.CustomControls
{
    public class WhiteRepeatButton : RepeatButton
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteRepeatButtonPeer(this);
        }
    }
}