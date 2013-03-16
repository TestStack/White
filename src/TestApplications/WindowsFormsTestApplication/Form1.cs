using System.Windows.Forms;

namespace WindowsFormsTestApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void GetMultiple_Click(object sender, System.EventArgs e)
        {
            new GetMultiple().ShowDialog();
        }
    }
}
