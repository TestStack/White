namespace WindowsFormsTestApplication
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Grand Child");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Child", new System.Windows.Forms.TreeNode[] {
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Root", new System.Windows.Forms.TreeNode[] {
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Main");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ScenariosPane = new System.Windows.Forms.GroupBox();
            this.ReverseTabOrderButton = new System.Windows.Forms.Button();
            this.OpenWindowWithScrollbars = new System.Windows.Forms.Button();
            this.OpenWindowWithAmperstand = new System.Windows.Forms.Button();
            this.OpenWindowWithNoTitleBar = new System.Windows.Forms.Button();
            this.OpenMessageBox = new System.Windows.Forms.Button();
            this.CustomUIItemScenario = new System.Windows.Forms.Button();
            this.DragDropScenario = new System.Windows.Forms.Button();
            this.OpenFormWithoutScrollAndItemOutside = new System.Windows.Forms.Button();
            this.DisableControls = new System.Windows.Forms.Button();
            this.OpenListView = new System.Windows.Forms.Button();
            this.GetMultipleButton = new System.Windows.Forms.Button();
            this.ButtonWithTooltip = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.LinkLabel = new System.Windows.Forms.LinkLabel();
            this.ControlsTab = new System.Windows.Forms.TabControl();
            this.ListControlsTab = new System.Windows.Forms.TabPage();
            this.InputControlsTab = new System.Windows.Forms.TabPage();
            this.OtherControlsTab = new System.Windows.Forms.TabPage();
            this.AddNode = new System.Windows.Forms.Button();
            this.TreeView = new System.Windows.Forms.TreeView();
            this.Slider = new System.Windows.Forms.TrackBar();
            this.Image = new System.Windows.Forms.PictureBox();
            this.HiddenTextBox = new System.Windows.Forms.TextBox();
            this.AddTextBoxPanel = new System.Windows.Forms.Panel();
            this.AddTextBox = new System.Windows.Forms.Button();
            this.ShowHiddenTextBox = new System.Windows.Forms.Button();
            this.PanelWithText = new System.Windows.Forms.Panel();
            this.TextBoxInsidePanel = new System.Windows.Forms.TextBox();
            this.DataGridTab = new System.Windows.Forms.TabPage();
            this.DataGrid = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.country = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.alive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.display = new System.Windows.Forms.DataGridViewButtonColumn();
            this.details = new System.Windows.Forms.DataGridViewLinkColumn();
            this.PropertyGridTab = new System.Windows.Forms.TabPage();
            this.PropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.ToolStrip2 = new System.Windows.Forms.ToolStrip();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clickMeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.twoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.splitButtonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripProgressBar2 = new System.Windows.Forms.ToolStripProgressBar();
            this.listControls1 = new WindowsFormsTestApplication.ListControls();
            this.inputControls1 = new WindowsFormsTestApplication.InputControls();
            this.DataGridControl = new System.Windows.Forms.DataGridView();
            this.ScenariosPane.SuspendLayout();
            this.ControlsTab.SuspendLayout();
            this.ListControlsTab.SuspendLayout();
            this.InputControlsTab.SuspendLayout();
            this.OtherControlsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Slider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Image)).BeginInit();
            this.PanelWithText.SuspendLayout();
            this.DataGridTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.PropertyGridTab.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridControl)).BeginInit();
            this.SuspendLayout();
            // 
            // ScenariosPane
            // 
            this.ScenariosPane.Controls.Add(this.ReverseTabOrderButton);
            this.ScenariosPane.Controls.Add(this.OpenWindowWithScrollbars);
            this.ScenariosPane.Controls.Add(this.OpenWindowWithAmperstand);
            this.ScenariosPane.Controls.Add(this.OpenWindowWithNoTitleBar);
            this.ScenariosPane.Controls.Add(this.OpenMessageBox);
            this.ScenariosPane.Controls.Add(this.CustomUIItemScenario);
            this.ScenariosPane.Controls.Add(this.DragDropScenario);
            this.ScenariosPane.Controls.Add(this.OpenFormWithoutScrollAndItemOutside);
            this.ScenariosPane.Controls.Add(this.DisableControls);
            this.ScenariosPane.Controls.Add(this.OpenListView);
            this.ScenariosPane.Controls.Add(this.GetMultipleButton);
            this.ScenariosPane.Controls.Add(this.ButtonWithTooltip);
            this.ScenariosPane.Location = new System.Drawing.Point(716, 77);
            this.ScenariosPane.Name = "ScenariosPane";
            this.ScenariosPane.Size = new System.Drawing.Size(254, 324);
            this.ScenariosPane.TabIndex = 5;
            this.ScenariosPane.TabStop = false;
            this.ScenariosPane.Text = "Scenarios";
            // 
            // ReverseTabOrderButton
            // 
            this.ReverseTabOrderButton.Location = new System.Drawing.Point(7, 222);
            this.ReverseTabOrderButton.Name = "ReverseTabOrderButton";
            this.ReverseTabOrderButton.Size = new System.Drawing.Size(115, 23);
            this.ReverseTabOrderButton.TabIndex = 11;
            this.ReverseTabOrderButton.Text = "Reverse Tab Order";
            this.ReverseTabOrderButton.UseVisualStyleBackColor = true;
            this.ReverseTabOrderButton.Click += new System.EventHandler(this.ReverseTabOrderButton_Click);
            // 
            // OpenWindowWithScrollbars
            // 
            this.OpenWindowWithScrollbars.Location = new System.Drawing.Point(6, 193);
            this.OpenWindowWithScrollbars.Name = "OpenWindowWithScrollbars";
            this.OpenWindowWithScrollbars.Size = new System.Drawing.Size(242, 23);
            this.OpenWindowWithScrollbars.TabIndex = 10;
            this.OpenWindowWithScrollbars.Text = "Window With Scrollbars";
            this.OpenWindowWithScrollbars.UseVisualStyleBackColor = true;
            this.OpenWindowWithScrollbars.Click += new System.EventHandler(this.OpenWindowWithScrollbars_Click);
            // 
            // OpenWindowWithAmperstand
            // 
            this.OpenWindowWithAmperstand.Location = new System.Drawing.Point(7, 164);
            this.OpenWindowWithAmperstand.Name = "OpenWindowWithAmperstand";
            this.OpenWindowWithAmperstand.Size = new System.Drawing.Size(241, 23);
            this.OpenWindowWithAmperstand.TabIndex = 9;
            this.OpenWindowWithAmperstand.Text = "Window With Amperstand";
            this.OpenWindowWithAmperstand.UseVisualStyleBackColor = true;
            this.OpenWindowWithAmperstand.Click += new System.EventHandler(this.OpenWindowWithAmperstand_Click);
            // 
            // OpenWindowWithNoTitleBar
            // 
            this.OpenWindowWithNoTitleBar.Location = new System.Drawing.Point(126, 135);
            this.OpenWindowWithNoTitleBar.Name = "OpenWindowWithNoTitleBar";
            this.OpenWindowWithNoTitleBar.Size = new System.Drawing.Size(122, 23);
            this.OpenWindowWithNoTitleBar.TabIndex = 8;
            this.OpenWindowWithNoTitleBar.Text = "No Title Bar Window";
            this.OpenWindowWithNoTitleBar.UseVisualStyleBackColor = true;
            this.OpenWindowWithNoTitleBar.Click += new System.EventHandler(this.OpenWindowWithNoTitleBar_Click);
            // 
            // OpenMessageBox
            // 
            this.OpenMessageBox.Location = new System.Drawing.Point(7, 135);
            this.OpenMessageBox.Name = "OpenMessageBox";
            this.OpenMessageBox.Size = new System.Drawing.Size(115, 23);
            this.OpenMessageBox.TabIndex = 7;
            this.OpenMessageBox.Text = "Open Message Box";
            this.OpenMessageBox.UseVisualStyleBackColor = true;
            this.OpenMessageBox.Click += new System.EventHandler(this.OpenMessageBox_Click);
            // 
            // CustomUIItemScenario
            // 
            this.CustomUIItemScenario.Location = new System.Drawing.Point(128, 106);
            this.CustomUIItemScenario.Name = "CustomUIItemScenario";
            this.CustomUIItemScenario.Size = new System.Drawing.Size(120, 23);
            this.CustomUIItemScenario.TabIndex = 6;
            this.CustomUIItemScenario.Text = "Custom UI Item";
            this.CustomUIItemScenario.UseVisualStyleBackColor = true;
            this.CustomUIItemScenario.Click += new System.EventHandler(this.CustomUIItemScenario_Click);
            // 
            // DragDropScenario
            // 
            this.DragDropScenario.Location = new System.Drawing.Point(7, 106);
            this.DragDropScenario.Name = "DragDropScenario";
            this.DragDropScenario.Size = new System.Drawing.Size(115, 23);
            this.DragDropScenario.TabIndex = 5;
            this.DragDropScenario.Text = "Drag Drop Scenario";
            this.DragDropScenario.UseVisualStyleBackColor = true;
            this.DragDropScenario.Click += new System.EventHandler(this.DragDropScenario_Click);
            // 
            // OpenFormWithoutScrollAndItemOutside
            // 
            this.OpenFormWithoutScrollAndItemOutside.Location = new System.Drawing.Point(7, 77);
            this.OpenFormWithoutScrollAndItemOutside.Name = "OpenFormWithoutScrollAndItemOutside";
            this.OpenFormWithoutScrollAndItemOutside.Size = new System.Drawing.Size(241, 23);
            this.OpenFormWithoutScrollAndItemOutside.TabIndex = 4;
            this.OpenFormWithoutScrollAndItemOutside.Text = "FormWithoutScrollAndControlOutside";
            this.OpenFormWithoutScrollAndItemOutside.UseVisualStyleBackColor = true;
            this.OpenFormWithoutScrollAndItemOutside.Click += new System.EventHandler(this.OpenFormWithoutScrollAndControlOutside_Click);
            // 
            // DisableControls
            // 
            this.DisableControls.Location = new System.Drawing.Point(128, 48);
            this.DisableControls.Name = "DisableControls";
            this.DisableControls.Size = new System.Drawing.Size(120, 23);
            this.DisableControls.TabIndex = 3;
            this.DisableControls.Text = "Disable Controls";
            this.DisableControls.UseVisualStyleBackColor = true;
            this.DisableControls.Click += new System.EventHandler(this.DisableControls_Click);
            // 
            // OpenListView
            // 
            this.OpenListView.Location = new System.Drawing.Point(7, 48);
            this.OpenListView.Name = "OpenListView";
            this.OpenListView.Size = new System.Drawing.Size(115, 23);
            this.OpenListView.TabIndex = 2;
            this.OpenListView.Text = "ListView Control";
            this.OpenListView.UseVisualStyleBackColor = true;
            this.OpenListView.Click += new System.EventHandler(this.OpenListView_Click);
            // 
            // GetMultipleButton
            // 
            this.GetMultipleButton.Location = new System.Drawing.Point(128, 19);
            this.GetMultipleButton.Name = "GetMultipleButton";
            this.GetMultipleButton.Size = new System.Drawing.Size(120, 23);
            this.GetMultipleButton.TabIndex = 1;
            this.GetMultipleButton.Text = "Get Multiple";
            this.GetMultipleButton.UseVisualStyleBackColor = true;
            this.GetMultipleButton.Click += new System.EventHandler(this.GetMultiple_Click);
            // 
            // ButtonWithTooltip
            // 
            this.ButtonWithTooltip.Location = new System.Drawing.Point(6, 19);
            this.ButtonWithTooltip.Name = "ButtonWithTooltip";
            this.ButtonWithTooltip.Size = new System.Drawing.Size(116, 23);
            this.ButtonWithTooltip.TabIndex = 0;
            this.ButtonWithTooltip.Text = "&Button with Tooltip";
            this.toolTip1.SetToolTip(this.ButtonWithTooltip, "I have a tooltip");
            this.ButtonWithTooltip.UseVisualStyleBackColor = true;
            this.ButtonWithTooltip.Click += new System.EventHandler(this.ButtonWithTooltip_Click);
            this.ButtonWithTooltip.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonWithTooltip_MouseClick);
            this.ButtonWithTooltip.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonWithTooltip_MouseUp);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(15, 36);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(100, 23);
            this.ProgressBar.TabIndex = 8;
            this.ProgressBar.Value = 50;
            // 
            // LinkLabel
            // 
            this.LinkLabel.Location = new System.Drawing.Point(12, 14);
            this.LinkLabel.Name = "LinkLabel";
            this.LinkLabel.Size = new System.Drawing.Size(63, 18);
            this.LinkLabel.TabIndex = 7;
            this.LinkLabel.TabStop = true;
            this.LinkLabel.Text = "Link Text";
            this.LinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_LinkClicked);
            // 
            // ControlsTab
            // 
            this.ControlsTab.Controls.Add(this.ListControlsTab);
            this.ControlsTab.Controls.Add(this.InputControlsTab);
            this.ControlsTab.Controls.Add(this.OtherControlsTab);
            this.ControlsTab.Controls.Add(this.DataGridTab);
            this.ControlsTab.Controls.Add(this.PropertyGridTab);
            this.ControlsTab.Location = new System.Drawing.Point(12, 77);
            this.ControlsTab.Name = "ControlsTab";
            this.ControlsTab.SelectedIndex = 0;
            this.ControlsTab.Size = new System.Drawing.Size(697, 324);
            this.ControlsTab.TabIndex = 7;
            // 
            // ListControlsTab
            // 
            this.ListControlsTab.Controls.Add(this.listControls1);
            this.ListControlsTab.Location = new System.Drawing.Point(4, 22);
            this.ListControlsTab.Name = "ListControlsTab";
            this.ListControlsTab.Padding = new System.Windows.Forms.Padding(3);
            this.ListControlsTab.Size = new System.Drawing.Size(689, 298);
            this.ListControlsTab.TabIndex = 0;
            this.ListControlsTab.Text = "List Controls";
            this.ListControlsTab.UseVisualStyleBackColor = true;
            // 
            // InputControlsTab
            // 
            this.InputControlsTab.Controls.Add(this.inputControls1);
            this.InputControlsTab.Location = new System.Drawing.Point(4, 22);
            this.InputControlsTab.Name = "InputControlsTab";
            this.InputControlsTab.Padding = new System.Windows.Forms.Padding(3);
            this.InputControlsTab.Size = new System.Drawing.Size(689, 298);
            this.InputControlsTab.TabIndex = 1;
            this.InputControlsTab.Text = "Input Controls";
            this.InputControlsTab.UseVisualStyleBackColor = true;
            // 
            // OtherControlsTab
            // 
            this.OtherControlsTab.Controls.Add(this.AddNode);
            this.OtherControlsTab.Controls.Add(this.TreeView);
            this.OtherControlsTab.Controls.Add(this.Slider);
            this.OtherControlsTab.Controls.Add(this.Image);
            this.OtherControlsTab.Controls.Add(this.HiddenTextBox);
            this.OtherControlsTab.Controls.Add(this.AddTextBoxPanel);
            this.OtherControlsTab.Controls.Add(this.AddTextBox);
            this.OtherControlsTab.Controls.Add(this.ShowHiddenTextBox);
            this.OtherControlsTab.Controls.Add(this.PanelWithText);
            this.OtherControlsTab.Controls.Add(this.ProgressBar);
            this.OtherControlsTab.Controls.Add(this.LinkLabel);
            this.OtherControlsTab.Location = new System.Drawing.Point(4, 22);
            this.OtherControlsTab.Name = "OtherControlsTab";
            this.OtherControlsTab.Size = new System.Drawing.Size(689, 298);
            this.OtherControlsTab.TabIndex = 2;
            this.OtherControlsTab.Text = "Other Controls";
            this.OtherControlsTab.UseVisualStyleBackColor = true;
            // 
            // AddNode
            // 
            this.AddNode.Location = new System.Drawing.Point(271, 117);
            this.AddNode.Name = "AddNode";
            this.AddNode.Size = new System.Drawing.Size(75, 23);
            this.AddNode.TabIndex = 17;
            this.AddNode.Text = "Add Node";
            this.AddNode.UseVisualStyleBackColor = true;
            this.AddNode.Click += new System.EventHandler(this.AddNode_Click);
            // 
            // TreeView
            // 
            this.TreeView.Location = new System.Drawing.Point(271, 14);
            this.TreeView.Name = "TreeView";
            treeNode5.Name = "GrandChild";
            treeNode5.Text = "Grand Child";
            treeNode6.Name = "ChildNode";
            treeNode6.Text = "Child";
            treeNode7.Name = "RootNode";
            treeNode7.Text = "Root";
            treeNode8.Name = "Main";
            treeNode8.Text = "Main";
            this.TreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
            this.TreeView.Size = new System.Drawing.Size(199, 96);
            this.TreeView.TabIndex = 16;
            // 
            // Slider
            // 
            this.Slider.LargeChange = 4;
            this.Slider.Location = new System.Drawing.Point(139, 19);
            this.Slider.Name = "Slider";
            this.Slider.Size = new System.Drawing.Size(121, 45);
            this.Slider.TabIndex = 15;
            // 
            // Image
            // 
            this.Image.Image = ((System.Drawing.Image)(resources.GetObject("Image.Image")));
            this.Image.Location = new System.Drawing.Point(15, 200);
            this.Image.Name = "Image";
            this.Image.Size = new System.Drawing.Size(84, 86);
            this.Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Image.TabIndex = 14;
            this.Image.TabStop = false;
            // 
            // HiddenTextBox
            // 
            this.HiddenTextBox.Location = new System.Drawing.Point(160, 161);
            this.HiddenTextBox.Name = "HiddenTextBox";
            this.HiddenTextBox.Size = new System.Drawing.Size(100, 20);
            this.HiddenTextBox.TabIndex = 13;
            this.HiddenTextBox.Visible = false;
            // 
            // AddTextBoxPanel
            // 
            this.AddTextBoxPanel.Location = new System.Drawing.Point(114, 126);
            this.AddTextBoxPanel.Name = "AddTextBoxPanel";
            this.AddTextBoxPanel.Size = new System.Drawing.Size(146, 29);
            this.AddTextBoxPanel.TabIndex = 12;
            // 
            // AddTextBox
            // 
            this.AddTextBox.Location = new System.Drawing.Point(15, 132);
            this.AddTextBox.Name = "AddTextBox";
            this.AddTextBox.Size = new System.Drawing.Size(93, 23);
            this.AddTextBox.TabIndex = 11;
            this.AddTextBox.Text = "Add TextBox";
            this.AddTextBox.UseVisualStyleBackColor = true;
            this.AddTextBox.Click += new System.EventHandler(this.AddTextBox_Click);
            // 
            // ShowHiddenTextBox
            // 
            this.ShowHiddenTextBox.Location = new System.Drawing.Point(15, 161);
            this.ShowHiddenTextBox.Name = "ShowHiddenTextBox";
            this.ShowHiddenTextBox.Size = new System.Drawing.Size(138, 23);
            this.ShowHiddenTextBox.TabIndex = 10;
            this.ShowHiddenTextBox.Text = "Show Hidden TextBox";
            this.ShowHiddenTextBox.UseVisualStyleBackColor = true;
            this.ShowHiddenTextBox.Click += new System.EventHandler(this.ShowHiddenTextBox_Click);
            // 
            // PanelWithText
            // 
            this.PanelWithText.Controls.Add(this.TextBoxInsidePanel);
            this.PanelWithText.Location = new System.Drawing.Point(15, 70);
            this.PanelWithText.Name = "PanelWithText";
            this.PanelWithText.Size = new System.Drawing.Size(245, 50);
            this.PanelWithText.TabIndex = 9;
            // 
            // TextBoxInsidePanel
            // 
            this.TextBoxInsidePanel.Location = new System.Drawing.Point(165, 27);
            this.TextBoxInsidePanel.Name = "TextBoxInsidePanel";
            this.TextBoxInsidePanel.Size = new System.Drawing.Size(77, 20);
            this.TextBoxInsidePanel.TabIndex = 0;
            // 
            // DataGridTab
            // 
            this.DataGridTab.Controls.Add(this.DataGridControl);
            this.DataGridTab.Controls.Add(this.DataGrid);
            this.DataGridTab.Location = new System.Drawing.Point(4, 22);
            this.DataGridTab.Name = "DataGridTab";
            this.DataGridTab.Padding = new System.Windows.Forms.Padding(3);
            this.DataGridTab.Size = new System.Drawing.Size(689, 298);
            this.DataGridTab.TabIndex = 3;
            this.DataGridTab.Text = "Data Grid";
            this.DataGridTab.UseVisualStyleBackColor = true;
            // 
            // DataGrid
            // 
            this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.country,
            this.alive,
            this.display,
            this.details});
            this.DataGrid.Location = new System.Drawing.Point(6, 6);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.Size = new System.Drawing.Size(677, 130);
            this.DataGrid.TabIndex = 10;
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            // 
            // country
            // 
            this.country.HeaderText = "Country";
            this.country.Items.AddRange(new object[] {
            "India",
            "Sri Lanka",
            "Pakistan"});
            this.country.Name = "country";
            // 
            // alive
            // 
            this.alive.HeaderText = "Alive";
            this.alive.Name = "alive";
            // 
            // display
            // 
            this.display.HeaderText = "Display";
            this.display.Name = "display";
            this.display.Text = "Show";
            // 
            // details
            // 
            this.details.HeaderText = "Details";
            this.details.Name = "details";
            this.details.Text = "More..";
            // 
            // PropertyGridTab
            // 
            this.PropertyGridTab.Controls.Add(this.PropertyGrid);
            this.PropertyGridTab.Location = new System.Drawing.Point(4, 22);
            this.PropertyGridTab.Name = "PropertyGridTab";
            this.PropertyGridTab.Padding = new System.Windows.Forms.Padding(3);
            this.PropertyGridTab.Size = new System.Drawing.Size(689, 298);
            this.PropertyGridTab.TabIndex = 4;
            this.PropertyGridTab.Text = "Property Grid";
            this.PropertyGridTab.UseVisualStyleBackColor = true;
            // 
            // PropertyGrid
            // 
            this.PropertyGrid.Location = new System.Drawing.Point(6, 6);
            this.PropertyGrid.Name = "PropertyGrid";
            this.PropertyGrid.Size = new System.Drawing.Size(251, 286);
            this.PropertyGrid.TabIndex = 1;
            // 
            // ToolStrip2
            // 
            this.ToolStrip2.Location = new System.Drawing.Point(0, 24);
            this.ToolStrip2.Name = "ToolStrip2";
            this.ToolStrip2.Size = new System.Drawing.Size(982, 25);
            this.ToolStrip2.TabIndex = 29;
            this.ToolStrip2.Text = "toolStrip2";
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripLabel1,
            this.toolStripSplitButton1,
            this.toolStripDropDownButton1,
            this.toolStripComboBox1,
            this.toolStripTextBox1,
            this.toolStripProgressBar1});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 49);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(982, 25);
            this.ToolStrip1.TabIndex = 28;
            this.ToolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(86, 22);
            this.toolStripLabel1.Text = "toolStripLabel1";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 22);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 22);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(982, 24);
            this.menuStrip1.TabIndex = 30;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clickMeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // clickMeToolStripMenuItem
            // 
            this.clickMeToolStripMenuItem.Name = "clickMeToolStripMenuItem";
            this.clickMeToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.clickMeToolStripMenuItem.Text = "Click Me";
            this.clickMeToolStripMenuItem.Click += new System.EventHandler(this.clickMeToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // selectToolStripMenuItem
            // 
            this.selectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineToolStripMenuItem});
            this.selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            this.selectToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.selectToolStripMenuItem.Text = "Select";
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.lineToolStripMenuItem.Text = "Line";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStripLabel,
            this.toolStripProgressBar,
            this.toolStripDropDownButton,
            this.toolStripSplitButton,
            this.toolStripProgressBar2});
            this.statusStrip.Location = new System.Drawing.Point(0, 404);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(982, 22);
            this.statusStrip.TabIndex = 31;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusStripLabel
            // 
            this.statusStripLabel.Name = "statusStripLabel";
            this.statusStripLabel.Size = new System.Drawing.Size(97, 17);
            this.statusStripLabel.Text = "Status Strip Label";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Maximum = 75;
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar.Value = 25;
            // 
            // toolStripDropDownButton
            // 
            this.toolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.twoToolStripMenuItem,
            this.oneToolStripMenuItem});
            this.toolStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton.Image")));
            this.toolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton.Name = "toolStripDropDownButton";
            this.toolStripDropDownButton.Size = new System.Drawing.Size(29, 20);
            this.toolStripDropDownButton.Text = "toolStripDropDownButton";
            // 
            // twoToolStripMenuItem
            // 
            this.twoToolStripMenuItem.Name = "twoToolStripMenuItem";
            this.twoToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.twoToolStripMenuItem.Text = "Two";
            // 
            // oneToolStripMenuItem
            // 
            this.oneToolStripMenuItem.Name = "oneToolStripMenuItem";
            this.oneToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.oneToolStripMenuItem.Text = "One";
            // 
            // toolStripSplitButton
            // 
            this.toolStripSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.splitButtonToolStripMenuItem});
            this.toolStripSplitButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton.Image")));
            this.toolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton.Name = "toolStripSplitButton";
            this.toolStripSplitButton.Size = new System.Drawing.Size(32, 20);
            this.toolStripSplitButton.Text = "toolStripSplitButtonText";
            // 
            // splitButtonToolStripMenuItem
            // 
            this.splitButtonToolStripMenuItem.Name = "splitButtonToolStripMenuItem";
            this.splitButtonToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.splitButtonToolStripMenuItem.Text = "Split Button";
            // 
            // toolStripProgressBar2
            // 
            this.toolStripProgressBar2.Maximum = 75;
            this.toolStripProgressBar2.Name = "toolStripProgressBar2";
            this.toolStripProgressBar2.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar2.Value = 50;
            // 
            // listControls1
            // 
            this.listControls1.Location = new System.Drawing.Point(6, 19);
            this.listControls1.Name = "listControls1";
            this.listControls1.Size = new System.Drawing.Size(260, 204);
            this.listControls1.TabIndex = 0;
            // 
            // inputControls1
            // 
            this.inputControls1.Location = new System.Drawing.Point(6, 6);
            this.inputControls1.Name = "inputControls1";
            this.inputControls1.Size = new System.Drawing.Size(618, 286);
            this.inputControls1.TabIndex = 0;
            // 
            // DataGridControl
            // 
            this.DataGridControl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridControl.Location = new System.Drawing.Point(6, 142);
            this.DataGridControl.Name = "DataGridControl";
            this.DataGridControl.Size = new System.Drawing.Size(677, 150);
            this.DataGridControl.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 426);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.ToolStrip2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ControlsTab);
            this.Controls.Add(this.ScenariosPane);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainWindow";
            this.ScenariosPane.ResumeLayout(false);
            this.ControlsTab.ResumeLayout(false);
            this.ListControlsTab.ResumeLayout(false);
            this.InputControlsTab.ResumeLayout(false);
            this.OtherControlsTab.ResumeLayout(false);
            this.OtherControlsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Slider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Image)).EndInit();
            this.PanelWithText.ResumeLayout(false);
            this.PanelWithText.PerformLayout();
            this.DataGridTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.PropertyGridTab.ResumeLayout(false);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListControls listControls1;
        private InputControls inputControls1;
        private System.Windows.Forms.GroupBox ScenariosPane;
        private System.Windows.Forms.Button ButtonWithTooltip;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button GetMultipleButton;
        private System.Windows.Forms.Button OpenListView;
        private System.Windows.Forms.Button DisableControls;
        private System.Windows.Forms.Button OpenFormWithoutScrollAndItemOutside;
        private System.Windows.Forms.Button DragDropScenario;
        private System.Windows.Forms.Button CustomUIItemScenario;
        private System.Windows.Forms.Button OpenMessageBox;
        private System.Windows.Forms.Button OpenWindowWithNoTitleBar;
        private System.Windows.Forms.LinkLabel LinkLabel;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Button OpenWindowWithAmperstand;
        private System.Windows.Forms.TabControl ControlsTab;
        private System.Windows.Forms.TabPage ListControlsTab;
        private System.Windows.Forms.TabPage InputControlsTab;
        private System.Windows.Forms.TabPage OtherControlsTab;
        private System.Windows.Forms.Panel PanelWithText;
        private System.Windows.Forms.TextBox TextBoxInsidePanel;
        private System.Windows.Forms.Button OpenWindowWithScrollbars;
        private System.Windows.Forms.ToolStrip ToolStrip2;
        private System.Windows.Forms.ToolStrip ToolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.Panel AddTextBoxPanel;
        private System.Windows.Forms.Button AddTextBox;
        private System.Windows.Forms.Button ShowHiddenTextBox;
        private System.Windows.Forms.TextBox HiddenTextBox;
        private System.Windows.Forms.Button ReverseTabOrderButton;
        private System.Windows.Forms.PictureBox Image;
        private System.Windows.Forms.TrackBar Slider;
        private System.Windows.Forms.Button AddNode;
        private System.Windows.Forms.TreeView TreeView;
        private System.Windows.Forms.TabPage DataGridTab;
        private System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewComboBoxColumn country;
        private System.Windows.Forms.DataGridViewCheckBoxColumn alive;
        private System.Windows.Forms.DataGridViewButtonColumn display;
        private System.Windows.Forms.DataGridViewLinkColumn details;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clickMeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusStripLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem twoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oneToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton;
        private System.Windows.Forms.ToolStripMenuItem splitButtonToolStripMenuItem;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar2;
        private System.Windows.Forms.TabPage PropertyGridTab;
        private System.Windows.Forms.PropertyGrid PropertyGrid;
        private System.Windows.Forms.DataGridView DataGridControl;
    }
}

