using System.Windows.Automation.Peers;
using System.Windows.Controls;

namespace White.CustomPeers
{
    public class ButtonPeer : ButtonAutomationPeer
    {
        public ButtonPeer(Button button) : base(button)
        {
        }
    }
}