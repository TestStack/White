using System.Windows.Automation.Peers;
using System.Windows.Controls.Primitives;
using White.CustomControls.Peers;

namespace White.CustomControls
{
    public class WhiteScrollBar : ScrollBar
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteScrollBarPeer(this);
        }
    }
}