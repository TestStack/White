using System.Windows.Forms;

namespace WindowsFormsTestApplication
{
    public partial class ListControls : UserControl
    {
        public ListControls()
        {
            InitializeComponent();
        }

        private void ListControls_EnabledChanged(object sender, System.EventArgs e)
        {
            AComboBox.Enabled = Enabled;
            EditableComboBox.Enabled = Enabled;
            CheckedListBox.Enabled = Enabled;
        }

        private void mainToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ListBoxWithVScrollBar.AccessibleDescription = "Root2 Clicked";
        }

        private void level2ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ListBoxWithVScrollBar.AccessibleDescription = "Level 2 Clicked";
        }
    }
}
