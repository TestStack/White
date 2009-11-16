using System.Windows.Forms;

namespace WinFormsTestApp
{
    public partial class ListViewScenarios : Form
    {
        public ListViewScenarios()
        {
            InitializeComponent();
            listViewWithHorizontalScroll.Columns.Add("Key", -2, HorizontalAlignment.Center);
//            listViewWithHorizontalScroll.Columns.Add("Value", -2, HorizontalAlignment.Left);
            listViewWithHorizontalScroll.View = View.Details;
            AddListItem(listViewWithHorizontalScroll, "baz");
            AddListItem(listViewWithHorizontalScroll, "bardfgreerrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrre");
        }

        private static void AddListItem(ListView listView, string key)
        {
            ListViewItem viewItem = new ListViewItem(key);
            listView.Items.Add(viewItem);
            return;
        }
    }
}