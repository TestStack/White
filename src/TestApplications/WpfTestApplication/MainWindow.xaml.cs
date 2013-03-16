using System.Collections.ObjectModel;
using System.Windows;

namespace WpfTestApplication
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
        }

        public ObservableCollection<string> ListItems
        {
            get
            {
                return new ObservableCollection<string>
                    {
                        "Test",
                        "Test2",
                        "Test3",
                        "Test4",
                        "Test5"
                    };
            }
        }

        private void LaunchHorizontalGridSplitter(object sender, RoutedEventArgs e)
        {
            new HorizontalGridSplitter().ShowDialog();
        }

        private void LaunchVerticalGridSplitter(object sender, RoutedEventArgs e)
        {
            new VerticalGridSplitter().ShowDialog();
        }

        private void GetMultiple(object sender, RoutedEventArgs e)
        {
            new GetMultiple().ShowDialog();
        }
    }
}
