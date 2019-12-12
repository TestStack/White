namespace WindowsFormsTestApplication
{
    using System;
    using System.Windows.Forms;

    public partial class ListControls : UserControl
    {
        public ListControls()
        {
            InitializeComponent();
        }

        private void level2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListBoxWithVScrollBar.AccessibleDescription = "Level 2 Clicked";
        }

        private void ListControls_EnabledChanged(object sender, EventArgs e)
        {
            AComboBox.Enabled = Enabled;
            EditableComboBox.Enabled = Enabled;
            CheckedListBox.Enabled = Enabled;
        }

        private void mainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListBoxWithVScrollBar.AccessibleDescription = "Root2 Clicked";
        }
    }
}