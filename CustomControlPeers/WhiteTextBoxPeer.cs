using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using White.CustomControls.Automation;

namespace White.CustomControls.Peers
{
    public class WhiteTextBoxPeer : TextBoxAutomationPeer, IValueProvider
    {
        private readonly WhitePeer whitePeer;

        public WhiteTextBoxPeer(TextBox textBox) : base(textBox)
        {
            whitePeer = WhitePeer.CreateForValueProvider(this, textBox, () => textBox.Text, value => textBox.Text = value);
        }

        public override object GetPattern(PatternInterface patternInterface)
        {
            return whitePeer.GetPattern(patternInterface);
        }

        public virtual void SetValue(string command)
        {
            whitePeer.SetValue(command);
        }

        public virtual string Value
        {
            get { return whitePeer.Value; }
        }

        public virtual bool IsReadOnly
        {
            get { return whitePeer.IsReadOnly; }
        }
    }
}