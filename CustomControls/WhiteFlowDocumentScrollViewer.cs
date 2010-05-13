using System.Windows.Automation.Peers;
using System.Windows.Controls;
using White.CustomControls.Peers;

namespace White.CustomControls
{
    public class WhiteFlowDocumentScrollViewer : FlowDocumentScrollViewer
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteFlowDocumentScrollViewerPeer(this);
        }
    }
}