using System;
using System.Windows.Forms;

namespace RecorderAddIn
{
    public partial class MethodNameGeneratorAddIn : Form
    {
        private readonly MethodGenerator controller;

        public MethodNameGeneratorAddIn(MethodGenerator controller)
        {
            this.controller = controller;
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Hide();
            controller.LaunchRecorder(txtMethodName.Text.Trim());
            Close();
        }
    }
}