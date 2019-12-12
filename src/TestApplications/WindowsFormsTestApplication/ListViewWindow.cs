namespace WindowsFormsTestApplication
{
    using System;
    using System.Windows.Forms;

    public partial class ListViewWindow : Form
    {
        public ListViewWindow()
        {
            InitializeComponent();
        }

        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListView.SelectedIndices.Count == 0) return;
            ListView.AccessibleDescription = "ListView item selected - " + ListView.SelectedIndices[0];
        }
    }
}