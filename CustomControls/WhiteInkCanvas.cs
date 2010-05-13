using System.Windows.Automation.Peers;
using System.Windows.Controls;
using White.CustomControls.Peers;

namespace White.CustomControls
{
    public class WhiteInkCanvas : InkCanvas
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteInkCanvasPeer(this);
        }
    }
}