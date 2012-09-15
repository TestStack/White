using System.Windows.Automation.Peers;
using System.Windows.Controls;
using White.CustomControls.Peers;

namespace White.CustomControls
{
    public class WhiteListView : ListView
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteListViewPeer(this);
        }
    }
}