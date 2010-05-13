using System.Windows.Automation.Peers;
using System.Windows.Controls;
using White.CustomControls.Peers;

namespace White.CustomControls
{
    public class WhiteViewport3D : Viewport3D
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteViewport3DPeer(this);
        }
    }
}