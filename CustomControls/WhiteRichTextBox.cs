using System.Windows.Automation.Peers;
using System.Windows.Controls;
using White.CustomControls.Peers;

namespace White.CustomControls
{
    public class WhiteRichTextBox : RichTextBox
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new WhiteRichTextBoxPeer(this);
        }
    }
}