using System.Linq;
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
            PanelWithText.Text = "PanelText";
            var treeViewItem = new TreeNode("Lots Of Children");
            foreach (var i in Enumerable.Range(1, 50))
            {
                treeViewItem.Nodes.Add(new TreeNode("Child" + i));
            }
            TreeView.Nodes.Add(treeViewItem);
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

        private void OpenMessageBox_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show(this, "Close me", "Test message box", MessageBoxButtons.OK);
        }

        private void OpenWindowWithNoTitleBar_Click(object sender, System.EventArgs e)
        {
            new WindowWithNoTitleBar().ShowDialog(this);
        }

        private void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel.AccessibleDescription = "Hyperlink Clicked";
        }

        private void OpenWindowWithAmperstand_Click(object sender, System.EventArgs e)
        {
            new WindowWithAmperstand().ShowDialog(this);
        }

        private void AddTextBox_Click(object sender, System.EventArgs e)
        {
            AddTextBoxPanel.Controls.Add(new TextBox { Name = "AddedTextBox" });
        }

        private void ShowHiddenTextBox_Click(object sender, System.EventArgs e)
        {
            HiddenTextBox.Visible = true;
        }

        private void OpenWindowWithScrollbars_Click(object sender, System.EventArgs e)
        {
            new WindowWithScrollbars().ShowDialog(this);
        }

        private void ReverseTabOrderButton_Click(object sender, System.EventArgs e)
        {
            ControlsTab.RightToLeft = RightToLeft.Yes;
            ControlsTab.RightToLeftLayout = true;
        }

        private void AddNode_Click(object sender, System.EventArgs e)
        {
            TreeView.Nodes.Add("AddedNode");
        }
    }
}
