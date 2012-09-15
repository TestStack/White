using System.Windows.Automation.Peers;
using System.Windows.Controls;
using White.CustomControls.Peers;

namespace White.CustomControls
{
    public class WhiteExpander : Expander
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteExpanderPeer(this);
        }
    }
}