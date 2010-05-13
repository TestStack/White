using System.Windows.Automation.Peers;
using System.Windows.Navigation;
using White.CustomControls.Peers;

namespace White.CustomControls
{
    public class WhiteNavigationWindow : NavigationWindow
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteNavigationWindowPeer(this);
        }
    }
}