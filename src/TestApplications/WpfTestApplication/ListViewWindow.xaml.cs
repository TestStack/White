using System.Collections.ObjectModel;

namespace WpfTestApplication
{
    public partial class ListViewWindow
    {
        private readonly ObservableCollection<ListViewData> listViewItems;

        public ListViewWindow()
        {
            listViewItems = new ObservableCollection<ListViewData>
            {
                new ListViewData("Search", "Google"),
                new ListViewData("Mail", "GMail"),
                new ListViewData("Picture", "Piccasa")
            };
            InitializeComponent();
        }

        public ObservableCollection<ListViewData> ListViewItems
        {
            get { return listViewItems; }
        }
    }
}
