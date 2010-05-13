using System.Windows.Automation.Peers;
using System.Windows.Controls;
using White.CustomControls.Peers;

namespace White.CustomControls
{
    public class WhiteFlowDocumentReader : FlowDocumentReader
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteFlowDocumentReaderPeer(this);
        }
    }
}