﻿namespace WindowsFormsTestApplication
{
    using System;
    using System.Linq;
    using System.Windows.Forms;

    using WindowsFormsTestApplication.Scenarios;
    using WindowsFormsTestApplication.Scenarios.CustomUIItem;

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
            PopulateDataGrid();
            PropertyGrid.SelectedObject = new BasicTypes("str", false, 6, 1.2f);
            DataGridControl.DataSource = TestItems;
        }

        public TestItem[] TestItems
        {
            get
            {
                return new[]
                           {
                               new TestItem { Id = 1, Contents = "Item1", Description = "Simple item 1" }, 
                               new TestItem { Id = 2, Contents = "Item2", Description = string.Empty }, 
                               new TestItem { Id = 3, Contents = "Item3" }
                           };
            }
        }

        private void AddNode_Click(object sender, EventArgs e)
        {
            TreeView.Nodes.Add("AddedNode");
        }

        private void AddTextBox_Click(object sender, EventArgs e)
        {
            AddTextBoxPanel.Controls.Add(new TextBox { Name = "AddedTextBox" });
        }

        private void ButtonWithTooltip_Click(object sender, EventArgs e)
        {
            ButtonWithTooltip.Text = "Clicked";
        }

        private void ButtonWithTooltip_MouseClick(object sender, MouseEventArgs e)
        {
            ButtonWithTooltip.Text = "Button Clicked with Mouse";
        }

        private void ButtonWithTooltip_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) ButtonWithTooltip.Text = "Right click received";
        }

        private void clickMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccessibleDescription = "Click Me Clicked";
        }

        private void CustomUIItemScenario_Click(object sender, EventArgs e)
        {
            new CustomUIItemScenario().ShowDialog(this);
        }

        private void DisableControls_Click(object sender, EventArgs e)
        {
            controlsEnabled = !controlsEnabled;
            SetEnabled(controlsEnabled);
            DisableControls.Text = controlsEnabled ? "Enable Controls" : "Disable Controls";
        }

        private void DragDropScenario_Click(object sender, EventArgs e)
        {
            new DragAndDropTestWindow().ShowDialog();
        }

        private void GetMultiple_Click(object sender, EventArgs e)
        {
            new GetMultiple().ShowDialog();
        }

        private void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel.AccessibleDescription = "Hyperlink Clicked";
        }

        private void OpenFormWithoutScrollAndControlOutside_Click(object sender, EventArgs e)
        {
            new FormWithoutScrollAndItemOutside().ShowDialog();
        }

        private void OpenListView_Click(object sender, EventArgs e)
        {
            new ListViewWindow().ShowDialog();
        }

        private void OpenMessageBox_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Close me", "Test message box", MessageBoxButtons.OK);
        }

        private void OpenWindowWithAmperstand_Click(object sender, EventArgs e)
        {
            new WindowWithAmperstand().ShowDialog(this);
        }

        private void OpenWindowWithNoTitleBar_Click(object sender, EventArgs e)
        {
            new WindowWithNoTitleBar().ShowDialog(this);
        }

        private void OpenWindowWithScrollbars_Click(object sender, EventArgs e)
        {
            new WindowWithScrollbars().ShowDialog(this);
        }

        private void PopulateDataGrid()
        {
            DataGrid.Rows.Add("Imran", "Pakistan", true, "Show", "More..");
            DataGrid.Rows.Add("Jayasurya", "Sri Lanka", true, "Show", "More..");
            DataGrid.Rows.Add("Raman Lamba", "India", false, "Show", "More..");
            DataGrid.Rows.Add("Empty", "India", false, "Empty", "Empty");
            DataGrid.Rows.Add("Empty", "India", false, "Empty", "Empty");
            DataGrid.Rows.Add("Empty", "India", false, "Empty", "Empty");
            DataGrid.Rows.Add("Empty", "India", false, "Empty", "Empty");
            DataGrid.Rows.Add("Empty", "India", false, "Empty", "Empty");
            DataGrid.Rows.Add("Empty", "India", false, "Empty", "Empty");
            DataGrid.Rows.Add("Empty", "India", false, "Empty", "Empty");
            DataGrid.Rows.Add("Empty", "India", false, "Empty", "Empty");
            DataGrid.Rows.Add("Empty", "India", false, "Empty", "Empty");
            DataGrid.Rows[2].Cells[1].ReadOnly = true;
        }

        private void ReverseTabOrderButton_Click(object sender, EventArgs e)
        {
            ControlsTab.RightToLeft = RightToLeft.Yes;
            ControlsTab.RightToLeftLayout = true;
        }

        private void SetEnabled(bool enabled)
        {
            listControls1.Enabled = enabled;
            inputControls1.Enabled = enabled;
        }

        private void ShowHiddenTextBox_Click(object sender, EventArgs e)
        {
            HiddenTextBox.Visible = true;
        }
    }
}