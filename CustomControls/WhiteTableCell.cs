using System.Windows.Automation.Peers;
using System.Windows.Documents;
using White.CustomControls.Peers;

namespace White.CustomControls
{
    public class WhiteTableCell : TableCell
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteTableCellPeer(this);
        }
    }
}