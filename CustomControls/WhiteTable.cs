using System.Windows.Automation.Peers;
using System.Windows.Documents;
using White.CustomControls.Peers;

namespace White.CustomControls
{
    public class WhiteTable : Table
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteTablePeer(this);
        }
    }
}