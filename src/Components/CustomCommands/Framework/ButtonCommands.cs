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

        public virtual double BorderBottomThickness
        {
            get { return button.BorderThickness.Bottom; }
        }

        public virtual Thickness BorderThickness
        {
            get { return new Thickness(button.BorderThickness); }
        }
    }
}