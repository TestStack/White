using System.Windows.Forms;
using WindowsFormsTestApplication.Scenarios;
using WindowsFormsTestApplication.Scenarios.CustomUIItem;

namespace WindowsFormsTestApplication
{
    public partial class Form1 : Form
    {
        private bool controlsEnabled = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void GetMultiple_Click(object sender, System.EventArgs e)
        {
            new GetMultiple().ShowDialog();
        }

        private void OpenListView_Click(object sender, System.EventArgs e)
        {
            new ListViewWindow().ShowDialog();
        }

        private void ButtonWithTooltip_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                ButtonWithTooltip.Text = "Right click received";
        }

        private void ButtonWithTooltip_Click(object sender, System.EventArgs e)
        {
            ButtonWithTooltip.Text = "Clicked";
        }

        private void ButtonWithTooltip_MouseClick(object sender, MouseEventArgs e)
        {
            ButtonWithTooltip.Text = "Button Clicked with Mouse";
        }

        private void DisableControls_Click(object sender, System.EventArgs e)
        {
            controlsEnabled = !controlsEnabled;
            SetEnabled(controlsEnabled);
            DisableControls.Text = controlsEnabled ? "Enable Controls" : "Disable Controls";
        }

        private void SetEnabled(bool enabled)
        {
            listControls1.Enabled = enabled;
            inputControls1.Enabled = enabled;
        }

        private void OpenFormWithoutScrollAndControlOutside_Click(object sender, System.EventArgs e)
        {
            new FormWithoutScrollAndItemOutside().ShowDialog();
        }

        private void DragDropScenario_Click(object sender, System.EventArgs e)
        {
            new DragAndDropTestWindow().ShowDialog();
        }

        private void CustomUIItemScenario_Click(object sender, System.EventArgs e)
        {
            new CustomUIItemScenario().ShowDialog(this);
        }
    }
}
