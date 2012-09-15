using System.Windows.Automation.Peers;
using System.Windows.Controls;
using White.CustomControls.Peers;

namespace White.CustomControls
{
    public class WhiteFlowDocumentPageViewer : FlowDocumentPageViewer
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteFlowDocumentPageViewerPeer(this);
        }
    }
}