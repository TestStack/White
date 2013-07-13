using System.Collections.ObjectModel;
using System.Windows.Automation;
using System.Windows.Controls;

namespace WpfTestApplication
{
    public partial class ListViewWindow
    {
        private readonly ObservableCollection<ListViewData> listViewItems;
        private readonly ObservableCollection<ListViewData> listViewItemsWitScroll;

        public ListViewWindow()
        {
            DataContext = this;
            listViewItems = new ObservableCollection<ListViewData>
            {
                new ListViewData("Search", "Google"),
                new ListViewData("Mail", "GMail"),
                new ListViewData("Picture", "Piccasa")
            };
            listViewItemsWitScroll = new ObservableCollection<ListViewData>
            {
                new ListViewData("baz", null),
                new ListViewData("bardfgreerrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrre", null)
            }; 
            InitializeComponent();
        }

        public ObservableCollection<ListViewData> ListViewItems
        {
            get { return listViewItems; }
        }

        public ObservableCollection<ListViewData> ListViewItemsWithScroll
        {
            get { return listViewItemsWitScroll; }
        }

        private void ListViewOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AutomationProperties.SetHelpText(ListView, "ListView item selected - " + ListView.SelectedIndex);
        }
    }
}
