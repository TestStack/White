using System.Windows;

namespace WpfTestApplication
{
    public partial class WindowLaunchers
    {
        public WindowLaunchers()
        {
            InitializeComponent();
        }

        private void LaunchHorizontalGridSplitter(object sender, RoutedEventArgs e)
        {
            new HorizontalGridSplitter().Show();
        }

        private void LaunchVerticalGridSplitter(object sender, RoutedEventArgs e)
        {
            new VerticalGridSplitter().Show();
        }
    }
}
