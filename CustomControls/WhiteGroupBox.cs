using System.Windows.Automation.Peers;
using System.Windows.Controls;
using White.CustomControls.Peers;

namespace White.CustomControls
{
    public class WhiteGroupBox : GroupBox
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteGroupBoxPeer(this);
        }
    }
}