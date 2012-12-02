using System;
using System.Windows.Forms;

namespace WinFormsTestApp
{
    public partial class PasswordForm : Form
    {
        public PasswordForm()
        {
            InitializeComponent();
            button1.Click += button1_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.PasswordChar = (char) 0;
        }
    }
}