using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WinFormsTestApp
{
    //TODO: Make unit tests faster by distributing the UIItems
    public partial class Form1 : Form
    {
        private readonly bool modalAtClose;

        public Form1(bool modalAtClose)
        {
            this.modalAtClose = modalAtClose;
            InitializeComponent();
            PopulateDataGrid();
            PopulateListView();
            buton.Click += buton_Click;
            linkLabel.LinkClicked += linkLabel_LinkClicked;
            textBox.TextChanged += textBox_TextChanged;
            launchModal.Click += launchModal_Click;
            showFilmsToolStripMenuItem.Click += ShowFilms;
            level2ToolStripMenuItem.Click += Level2Click;
            addNode.Click += AddNode;
            showError.Click += SetError;
            invisibleControlShower.Click += delegate { dynamicControl.Visible = true; };
            myNameIsDuplicateBox.Name = "duplicateBox";
            iAmDuplicateBox.Name = "duplicateBox";
            checkBoxLaunchedModalWindow.CheckStateChanged += checkBoxLaunchedModalWindow_CheckStateChanged;
            linkLaunchesModalWindow.LinkClicked += LinkLaunchClicked;
            treeViewLaunchesModal.NodeMouseDoubleClick += treeViewLaunchesModal_NodeMouseDoubleClick;
            comboBoxLaunchingModalWindow.SelectedIndexChanged += comboBoxLaunchingModalWindow_SelectedIndexChanged;
            addDynamicControl.Click += addDynamicControl_Click;
            progressBar.Maximum = 100;
            progressBar.Minimum = 0;
            progressBar.Value = 50;

            toolStripProgressBar.Minimum = 0;
            toolStripProgressBar.Maximum = 75;
            toolStripProgressBar.Value = 25;

            toolStripProgressBar2.Minimum = 0;
            toolStripProgressBar2.Maximum = 75;
            toolStripProgressBar2.Value = 50;

            clickMeToolStripMenuItem.Click += clickMeToolStripMenuItem_Click;
            multilineTextBox.Text = "dsfdsf";

            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.MouseDown += textBox_MouseDown;
            buton.AllowDrop = true;
            buton.DragEnter += buton_DragEnter;
            spring.AllowDrop = true;
            spring.DragEnter += DraggedOnTab;

            image.Click += image_Click;

            disableControls.Click += DisableControls;
            buttonInGroupBox.Click += buttonInGroupBox_Click;

            listViewForScenarioTest.Items.Add("foo");
            listViewForScenarioTest.Items.Add("bar");

            listView.DoubleClick += ListViewDoubleClicked;

            buttonLaunchesMessageBox.Click += LaunchMessageBox;

            panelWithText.Text = "PanelText";
            panelWithText.Visible = true;
            StartPosition = FormStartPosition.Manual;
            Location = new Point(0, 0);

            textBox.BackColor = Color.Blue;
            textBox.ForeColor = Color.Red;
        }

        private void DraggedOnTab(object sender, DragEventArgs e)
        {
            result.Text = "TextBoxDraggedOnTab";
        }

        private static void LaunchMessageBox(object sender, EventArgs e)
        {
            MessageBox.Show("Close Me", "Close Me");
        }

        private static void ListViewDoubleClicked(object sender, EventArgs e)
        {
            LaunchModalForm();
        }

        private void buttonInGroupBox_Click(object sender, EventArgs e)
        {
            result.Text = "Button In GroupBox Clicked";
        }

        private void DisableControls(object sender, EventArgs e)
        {
            textBox.Enabled = false;
            komboBox.Enabled = false;
        }

        private void image_Click(object sender, EventArgs e)
        {
            result.Text = "Image Clicked";
        }

        private void buton_DragEnter(object sender, DragEventArgs e)
        {
            result.Text = "TextBoxDraggedOnButton";
        }

        private void textBox_MouseDown(object sender, MouseEventArgs e)
        {
            textBox.DoDragDrop("Foo", DragDropEffects.Move);
        }

        private static void treeViewLaunchesModal_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            LaunchModalForm();
        }

        private void PopulateListView()
        {
            listView.View = View.Details;
            listView.Columns.Add("Key", -2, HorizontalAlignment.Center);
            listView.Columns.Add("Value", -2, HorizontalAlignment.Left);
            AddListItem(listView, "Search", "Google");
            AddListItem(listView, "Mail", "GMail");
            AddListItem(listView, "Picture", "Piccasa");
            AddListItem(listView, "OpenSource", "Code");
            AddListItem(listView, "HomePage", "Pages");
            AddListItem(listView, "Video", "YouTube");
            listView.ItemSelectionChanged += listView_ItemSelectionChanged;
        }

        private static void AddListItem(ListView listView, string key, string value)
        {
            var viewItem = new ListViewItem(key);
            viewItem.SubItems.Add(value);
            listView.Items.Add(viewItem);
            return;
        }

        private void listView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            result.Text = "listView item selected - " + e.ItemIndex;
        }

        private void clickMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            result.Text = "Click Me Clicked";
        }

        private void addDynamicControl_Click(object sender, EventArgs e)
        {
            var box = new TextBox();
            box.Name = "dynamicTextBox";
            hasDynamicControl.Controls.Add(box);
        }

        private static void comboBoxLaunchingModalWindow_SelectedIndexChanged(object sender, EventArgs e)
        {
            LaunchModalForm();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (modalAtClose)
                LaunchModalForm();
            base.OnClosing(e);
        }

        private static void LinkLaunchClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LaunchModalForm();
        }

        private static void checkBoxLaunchedModalWindow_CheckStateChanged(object sender, EventArgs e)
        {
            LaunchModalForm();
        }

        private static void LaunchModalForm()
        {
            Thread.Sleep(1000);
            var modalForm = new ModalForm();
            modalForm.ShowDialog();
        }

        private void SetError(object sender, EventArgs e)
        {
            var provider = new ErrorProvider();
            provider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            provider.SetError(komboBox, "The name is wrong");
        }

        private void AddNode(object sender, EventArgs e)
        {
            ped.Nodes.Add("DynamicNode");
        }

        private void Level2Click(object sender, EventArgs e)
        {
            result.Text = "Level2Click";
        }

        private void ShowFilms(object sender, EventArgs e)
        {
            result.Text = "All good films";
        }

        private static void launchModal_Click(object sender, EventArgs e)
        {
            LaunchModalForm();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            result.Text = "Text changed";
        }

        private void PopulateDataGrid()
        {
            people.Rows.Add("Imran", "Pakistan", true, "Show", "More..");
            people.Rows.Add("Jayasurya", "Sri Lanka", true, "Show", "More..");
            people.Rows.Add("Raman Lamba", "India", false, "Show", "More..");
            people.Rows.Add("Empty", "India", false, "Empty", "Empty");
            people.Rows.Add("Empty", "India", false, "Empty", "Empty");
            people.Rows.Add("Empty", "India", false, "Empty", "Empty");
            people.Rows.Add("Empty", "India", false, "Empty", "Empty");
            people.Rows.Add("Empty", "India", false, "Empty", "Empty");
            people.Rows.Add("Empty", "India", false, "Empty", "Empty");
            people.Rows.Add("Empty", "India", false, "Empty", "Empty");
            people.Rows.Add("Empty", "India", false, "Empty", "Empty");
            people.Rows.Add("Empty", "India", false, "Empty", "Empty");
            people.Rows[2].Cells[1].ReadOnly = true;
        }

        private void buton_Click(object sender, EventArgs e)
        {
            result.Text = "Button Clicked";
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            result.Text = "Link label clicked";
        }

        public void NoTableHeader()
        {
            people.ColumnHeadersVisible = false;
        }
    }
}