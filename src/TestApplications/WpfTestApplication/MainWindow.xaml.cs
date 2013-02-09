using System.Collections.ObjectModel;

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
    }
}
