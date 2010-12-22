using System.Windows.Controls;

namespace White.CustomCommands
{
    public class TextBoxCommands : ITextBoxCommands
    {
        private readonly TextBox textBox;

        public TextBoxCommands(TextBox textBox)
        {
            this.textBox = textBox;
        }

        public virtual void SelectText(string text)
        {
            string currentText = textBox.Text;
            textBox.Select(currentText.IndexOf(text), text.Length);
        }
    }
}