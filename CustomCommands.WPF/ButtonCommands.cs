using System.Windows.Controls;

namespace White.CustomCommands.WPF
{
    public class ButtonCommands : IButtonCommands
    {
        private readonly Button button;

        public ButtonCommands(Button button)
        {
            this.button = button;
        }

        public Thickness BorderThickness
        {
            get { return new Thickness(button.BorderThickness); }
        }
    }
}