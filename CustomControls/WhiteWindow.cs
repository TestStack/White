using System.Windows;
using System.Windows.Automation.Peers;
using White.CustomControls.Peers;

namespace White.CustomControls
{
    public class WhiteWindow : Window
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteWindowPeer(this);
        }
    }
}