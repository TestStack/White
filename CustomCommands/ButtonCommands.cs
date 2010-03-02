using System.Windows.Controls;

namespace White.CustomCommands
{
    public class ButtonCommands : IButtonCommands
    {
        private readonly Button button;

        public ButtonCommands(Button button)
        {
            this.button = button;
        }

        public double BorderBottomThickness
        {
            get { return button.BorderThickness.Bottom; }
        }

        public Thickness BorderThickness
        {
            get { return new Thickness(button.BorderThickness); }
        }
    }
}