using System.Windows.Automation.Peers;
using System.Windows.Documents;
using White.CustomControls.Peers;

namespace White.CustomControls
{
    public class WhiteHyperlink : Hyperlink
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteHyperlinkPeer(this);
        }
    }
}