using System.Windows;
using System.Windows.Automation.Peers;
using White.CustomControls.Peers;

namespace White.CustomControls
{
    public class WhiteFrameworkContentElement : FrameworkContentElement
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteFrameworkContentElementPeer(this);
        }
    }
}