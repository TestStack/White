using System.Windows;

namespace White.CustomCommands.WPFTestApplication
{
    /// <summary>
    /// Interaction logic for GridSplitter.xaml
    /// </summary>
    public partial class CustomWhiteControlsWindow : Window
    {
        public CustomWhiteControlsWindow()
        {
            InitializeComponent();
            button.BorderThickness = new Thickness(1, 1, 1, 1);
            listBox.Items.Add("Foo");
            listBox.Items.Add("Bar");
        }
    }
}