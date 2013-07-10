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
    }
}
