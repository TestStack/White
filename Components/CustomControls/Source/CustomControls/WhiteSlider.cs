using System.Windows.Automation.Peers;
using System.Windows.Controls;
using White.CustomControls.Peers;

namespace White.CustomControls
{
    public class WhiteSlider : Slider
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteSliderPeer(this);
        }
    }
}