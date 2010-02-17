using System.Windows.Controls;

namespace White.CustomCommands.WPF
{
    public class WPFWhiteButton : IWPFWhiteButton
    {
        private readonly Button button;

        public WPFWhiteButton(Button button)
        {
            this.button = button;
        }

        public Thickness BorderThickness
        {
            get { return new Thickness(button.BorderThickness); }
        }
    }
}