using System.Windows.Forms;

namespace WindowsFormsTestApplication
{
    public partial class InputControls : UserControl
    {
        public InputControls()
        {
            InitializeComponent();
        }

        private void InputControls_EnabledChanged(object sender, System.EventArgs e)
        {
            DatePicker.Enabled = Enabled;
            CheckBox.Enabled = Enabled;
            TextBox.Enabled = Enabled;
            MultiLineTextBox.Enabled = Enabled;
        }

        private void TextBox_TextChanged(object sender, System.EventArgs e)
        {
            TextBox.AccessibleDescription = "Text Changed";
        }

        private void UnmaskPasswordButton_Click(object sender, System.EventArgs e)
        {
            PasswordBox.UseSystemPasswordChar = false;
        }
    }
}
