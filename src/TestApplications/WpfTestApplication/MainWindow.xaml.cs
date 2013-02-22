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

        public TestItem[] TestItems        
        {
            get            
            {
                return new[]{
                               new TestItem {Id = 1, Contents = "Item1", Description = "Simple item 1"}, 
                               new TestItem {Id = 2, Contents = "Item2", Description = ""},
                               new TestItem {Id = 3, Contents = "Item3"}
                           };
            }
        }
    }
}
