using System.Windows.Automation.Peers;
using System.Windows.Controls;
using White.CustomControls.Peers;

namespace White.CustomControls
{
    public class WhiteDocumentViewer : DocumentViewer
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteDocumentViewerPeer(this);
        }
    }
}