using System.Windows.Automation.Peers;
using System.Windows.Controls;
using White.CustomControls.Peers;

namespace White.CustomControls
{
    public class WhiteInkPresenter : InkPresenter
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteInkPresenterPeer(this);
        }
    }
}