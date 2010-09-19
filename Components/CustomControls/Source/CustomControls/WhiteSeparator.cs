using System.Windows.Automation.Peers;
using System.Windows.Controls;
using White.CustomControls.Peers;

namespace White.CustomControls
{
    public class WhiteSeparator : Separator
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteSeparatorPeer(this);
        }
    }
}