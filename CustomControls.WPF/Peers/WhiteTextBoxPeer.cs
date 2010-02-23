using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using White.CustomControls.Automation;

namespace White.CustomControls.WPF.Peers
{
    public class WhiteTextBoxPeer : TextBoxAutomationPeer, IValueProvider
    {
        private readonly WhitePeer whitePeer;
        private readonly TextBox textBox;

        public WhiteTextBoxPeer(TextBox textBox) : base(textBox)
        {
            whitePeer = WhitePeer.CreateForValueProvider(this, textBox, () => textBox.Text);
            this.textBox = textBox;
        }

        public override object GetPattern(PatternInterface patternInterface)
        {
            return whitePeer.GetPattern(patternInterface);
        }

        public virtual void SetValue(string command)
        {
            if (string.IsNullOrEmpty(command))
            {
                textBox.Text = command;
                return;
            }
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