namespace WindowsFormsTestApplication
{
    using System;
    using System.Windows.Forms;

    public partial class InputControls : UserControl
    {
        public InputControls()
        {
            InitializeComponent();
        }

        private void InputControls_EnabledChanged(object sender, EventArgs e)
        {
            DatePicker.Enabled = Enabled;
            CheckBox.Enabled = Enabled;
            TextBox.Enabled = Enabled;
            MultiLineTextBox.Enabled = Enabled;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox.AccessibleDescription = "Text Changed";
        }

        private void UnmaskPasswordButton_Click(object sender, EventArgs e)
        {
            PasswordBox.UseSystemPasswordChar = false;
        }
    }
}