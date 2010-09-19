using System.Windows.Automation.Peers;
using System.Windows.Controls;
using White.CustomControls.Peers;

namespace White.CustomControls
{
    public class WhiteProgressBar : ProgressBar
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteProgressBarPeer(this);
        }
    }
}