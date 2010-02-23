using System.Windows.Controls;

namespace White.CustomCommands.Silverlight
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

        public double BottomBorderThickness
        {
            get { return button.BorderThickness.Bottom; }
        }
    }
}