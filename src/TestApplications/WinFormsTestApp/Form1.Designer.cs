namespace WinFormsTestApp
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Grand Child");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Child", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Root", new System.Windows.Forms.TreeNode[] {
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Main");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Child");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Root", new System.Windows.Forms.TreeNode[] {
            treeNode5});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buton = new System.Windows.Forms.Button();
            this.result = new System.Windows.Forms.Label();
            this.chequeBox = new System.Windows.Forms.CheckBox();
            this.chequedListBox = new System.Windows.Forms.CheckedListBox();
            this.komboBox = new System.Windows.Forms.ComboBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.listBox = new System.Windows.Forms.ListBox();
            this.listBoxPopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showFilmsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ped = new System.Windows.Forms.TreeView();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.people = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.country = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.alive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.display = new System.Windows.Forms.DataGridViewButtonColumn();
            this.details = new System.Windows.Forms.DataGridViewLinkColumn();
            this.textBox = new System.Windows.Forms.TextBox();
            this.listBoxWithVScrollBar = new System.Windows.Forms.ListBox();
            this.menuStripContainingMultilevelSubMenus = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.level1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.level2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchModal = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.seasons = new System.Windows.Forms.TabControl();
            this.spring = new System.Windows.Forms.TabPage();
            this.springyButton = new System.Windows.Forms.Button();
            this.springyTextBox = new System.Windows.Forms.TextBox();
            this.Autumn = new System.Windows.Forms.TabPage();
            this.autumnListBox = new System.Windows.Forms.ListBox();
            this.winter = new System.Windows.Forms.TabPage();
            this.iAmDuplicateBox = new System.Windows.Forms.TextBox();
            this.myNameIsDuplicateBox = new System.Windows.Forms.TextBox();
            this.addNode = new System.Windows.Forms.Button();
            this.showError = new System.Windows.Forms.Button();
            this.invisibleControlShower = new System.Windows.Forms.Button();
            this.dynamicControl = new System.Windows.Forms.Label();
            this.checkBoxLaunchedModalWindow = new System.Windows.Forms.CheckBox();
            this.linkLaunchesModalWindow = new System.Windows.Forms.LinkLabel();
            this.treeViewLaunchesModal = new System.Windows.Forms.TreeView();
            this.comboBoxLaunchingModalWindow = new System.Windows.Forms.ComboBox();
            this.checkedListBoxLaunchingModalWindow = new System.Windows.Forms.CheckedListBox();
            this.addDynamicControl = new System.Windows.Forms.Button();
            this.hasDynamicControl = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.twoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.splitButtonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripProgressBar2 = new System.Windows.Forms.ToolStripProgressBar();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchModalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clickMeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.listView = new System.Windows.Forms.ListView();
            this.multilineTextBox = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.image = new System.Windows.Forms.PictureBox();
            this.disableControls = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonInGroupBox = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxInsidePanel = new System.Windows.Forms.TextBox();
            this.listViewForScenarioTest = new System.Windows.Forms.ListView();
            this.invisible = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonLaunchesMessageBox = new System.Windows.Forms.Button();
            this.panelWithText = new System.Windows.Forms.Panel();
            this.hiddenButton = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.slider1 = new System.Windows.Forms.TrackBar();
            this.listBoxPopupMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.people)).BeginInit();
            this.menuStripContainingMultilevelSubMenus.SuspendLayout();
            this.seasons.SuspendLayout();
            this.spring.SuspendLayout();
            this.Autumn.SuspendLayout();
            this.winter.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider1)).BeginInit();
            this.SuspendLayout();
            // 
            // buton
            // 
            this.buton.Location = new System.Drawing.Point(13, 81);
            this.buton.Name = "buton";
            this.buton.Size = new System.Drawing.Size(75, 23);
            this.buton.TabIndex = 0;
            this.buton.Text = "&Buton";
            this.buton.UseVisualStyleBackColor = true;
            // 
            // result
            // 
            this.result.AutoSize = true;
            this.result.Location = new System.Drawing.Point(13, 447);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(37, 13);
            this.result.TabIndex = 1;
            this.result.Text = "Result";
            // 
            // chequeBox
            // 
            this.chequeBox.AutoSize = true;
            this.chequeBox.Location = new System.Drawing.Point(114, 85);
            this.chequeBox.Name = "chequeBox";
            this.chequeBox.Size = new System.Drawing.Size(84, 17);
            this.chequeBox.TabIndex = 2;
            this.chequeBox.Text = "Cheque Box";
            this.chequeBox.UseVisualStyleBackColor = true;
            // 
            // chequedListBox
            // 
            this.chequedListBox.FormattingEnabled = true;
            this.chequedListBox.Items.AddRange(new object[] {
            "Bill Gates",
            "Narayan Murthy"});
            this.chequedListBox.Location = new System.Drawing.Point(218, 81);
            this.chequedListBox.Name = "chequedListBox";
            this.chequedListBox.Size = new System.Drawing.Size(120, 94);
            this.chequedListBox.TabIndex = 3;
            // 
            // komboBox
            // 
            this.komboBox.DropDownWidth = 100;
            this.komboBox.FormattingEnabled = true;
            this.komboBox.Items.AddRange(new object[] {
            "Arundhati Roy",
            "Noam Chomsky",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "ReallyReallyLongTextHere"});
            this.komboBox.Location = new System.Drawing.Point(367, 80);
            this.komboBox.Name = "komboBox";
            this.komboBox.Size = new System.Drawing.Size(121, 21);
            this.komboBox.TabIndex = 4;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "ddmmyyyyhhmm";
            this.dateTimePicker.Location = new System.Drawing.Point(639, 81);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker.TabIndex = 5;
            // 
            // linkLabel
            // 
            this.linkLabel.Location = new System.Drawing.Point(875, 83);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(48, 18);
            this.linkLabel.TabIndex = 6;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "Linque";
            // 
            // listBox
            // 
            this.listBox.ContextMenuStrip = this.listBoxPopupMenu;
            this.listBox.FormattingEnabled = true;
            this.listBox.Items.AddRange(new object[] {
            "Speilberg",
            "Nagesh"});
            this.listBox.Location = new System.Drawing.Point(957, 80);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(120, 95);
            this.listBox.TabIndex = 7;
            // 
            // listBoxPopupMenu
            // 
            this.listBoxPopupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showFilmsToolStripMenuItem});
            this.listBoxPopupMenu.Name = "listBoxPopupMenu";
            this.listBoxPopupMenu.Size = new System.Drawing.Size(135, 26);
            // 
            // showFilmsToolStripMenuItem
            // 
            this.showFilmsToolStripMenuItem.Name = "showFilmsToolStripMenuItem";
            this.showFilmsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.showFilmsToolStripMenuItem.Text = "Show Films";
            // 
            // ped
            // 
            this.ped.Location = new System.Drawing.Point(16, 224);
            this.ped.Name = "ped";
            treeNode1.Name = "grandChild";
            treeNode1.Text = "Grand Child";
            treeNode2.Name = "childNode";
            treeNode2.Text = "Child";
            treeNode3.Name = "rootNode";
            treeNode3.Text = "Root";
            treeNode4.Name = "main";
            treeNode4.Text = "Main";
            this.ped.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            this.ped.Size = new System.Drawing.Size(199, 47);
            this.ped.TabIndex = 8;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(367, 132);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(40, 17);
            this.radioButton1.TabIndex = 9;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "foo";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(448, 132);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(40, 17);
            this.radioButton2.TabIndex = 10;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "bar";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // people
            // 
            this.people.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.people.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.country,
            this.alive,
            this.display,
            this.details});
            this.people.Location = new System.Drawing.Point(225, 224);
            this.people.Name = "people";
            this.people.Size = new System.Drawing.Size(599, 150);
            this.people.TabIndex = 9;
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
            // textBox
            // 
            this.textBox.AutoCompleteCustomSource.AddRange(new string[] {
            "hi",
            "hello"});
            this.textBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox.Location = new System.Drawing.Point(244, 196);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(100, 20);
            this.textBox.TabIndex = 9;
            this.textBox.Text = "userText";
            // 
            // listBoxWithVScrollBar
            // 
            this.listBoxWithVScrollBar.ContextMenuStrip = this.menuStripContainingMultilevelSubMenus;
            this.listBoxWithVScrollBar.FormattingEnabled = true;
            this.listBoxWithVScrollBar.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "0"});
            this.listBoxWithVScrollBar.Location = new System.Drawing.Point(244, 413);
            this.listBoxWithVScrollBar.Name = "listBoxWithVScrollBar";
            this.listBoxWithVScrollBar.Size = new System.Drawing.Size(120, 108);
            this.listBoxWithVScrollBar.TabIndex = 11;
            // 
            // menuStripContainingMultilevelSubMenus
            // 
            this.menuStripContainingMultilevelSubMenus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rootToolStripMenuItem,
            this.mainToolStripMenuItem});
            this.menuStripContainingMultilevelSubMenus.Name = "menuStripContainingMultilevelSubMenus";
            this.menuStripContainingMultilevelSubMenus.Size = new System.Drawing.Size(102, 48);
            // 
            // rootToolStripMenuItem
            // 
            this.rootToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.level1ToolStripMenuItem});
            this.rootToolStripMenuItem.Name = "rootToolStripMenuItem";
            this.rootToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.rootToolStripMenuItem.Text = "Root";
            // 
            // level1ToolStripMenuItem
            // 
            this.level1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.level2ToolStripMenuItem});
            this.level1ToolStripMenuItem.Name = "level1ToolStripMenuItem";
            this.level1ToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.level1ToolStripMenuItem.Text = "Level1";
            // 
            // level2ToolStripMenuItem
            // 
            this.level2ToolStripMenuItem.Name = "level2ToolStripMenuItem";
            this.level2ToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.level2ToolStripMenuItem.Text = "Level2";
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.mainToolStripMenuItem.Text = "Main";
            // 
            // launchModal
            // 
            this.launchModal.Location = new System.Drawing.Point(599, 392);
            this.launchModal.Name = "launchModal";
            this.launchModal.Size = new System.Drawing.Size(84, 23);
            this.launchModal.TabIndex = 12;
            this.launchModal.Text = "Launch Modal";
            this.launchModal.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(412, 392);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBox1.Size = new System.Drawing.Size(180, 40);
            this.textBox1.TabIndex = 12;
            this.textBox1.Text = "This control is used to test HScrollBar. It will display text long enought to dis" +
    "play HScrollBar";
            this.textBox1.WordWrap = false;
            // 
            // seasons
            // 
            this.seasons.Controls.Add(this.spring);
            this.seasons.Controls.Add(this.Autumn);
            this.seasons.Controls.Add(this.winter);
            this.seasons.Location = new System.Drawing.Point(412, 507);
            this.seasons.Name = "seasons";
            this.seasons.SelectedIndex = 0;
            this.seasons.Size = new System.Drawing.Size(448, 133);
            this.seasons.TabIndex = 12;
            // 
            // spring
            // 
            this.spring.Controls.Add(this.springyButton);
            this.spring.Controls.Add(this.springyTextBox);
            this.spring.Location = new System.Drawing.Point(4, 22);
            this.spring.Name = "spring";
            this.spring.Padding = new System.Windows.Forms.Padding(3);
            this.spring.Size = new System.Drawing.Size(440, 107);
            this.spring.TabIndex = 0;
            this.spring.Text = "Spring";
            this.spring.UseVisualStyleBackColor = true;
            // 
            // springyButton
            // 
            this.springyButton.Location = new System.Drawing.Point(132, 74);
            this.springyButton.Name = "springyButton";
            this.springyButton.Size = new System.Drawing.Size(75, 23);
            this.springyButton.TabIndex = 14;
            this.springyButton.Text = "Add Node";
            this.springyButton.UseVisualStyleBackColor = true;
            // 
            // springyTextBox
            // 
            this.springyTextBox.Location = new System.Drawing.Point(6, 74);
            this.springyTextBox.Name = "springyTextBox";
            this.springyTextBox.Size = new System.Drawing.Size(100, 20);
            this.springyTextBox.TabIndex = 10;
            this.springyTextBox.Text = "userText";
            // 
            // Autumn
            // 
            this.Autumn.Controls.Add(this.autumnListBox);
            this.Autumn.Location = new System.Drawing.Point(4, 22);
            this.Autumn.Name = "Autumn";
            this.Autumn.Padding = new System.Windows.Forms.Padding(3);
            this.Autumn.Size = new System.Drawing.Size(440, 107);
            this.Autumn.TabIndex = 1;
            this.Autumn.Text = "Autumn";
            this.Autumn.UseVisualStyleBackColor = true;
            // 
            // autumnListBox
            // 
            this.autumnListBox.ContextMenuStrip = this.listBoxPopupMenu;
            this.autumnListBox.FormattingEnabled = true;
            this.autumnListBox.Items.AddRange(new object[] {
            "Speilberg",
            "Nagesh"});
            this.autumnListBox.Location = new System.Drawing.Point(6, 71);
            this.autumnListBox.Name = "autumnListBox";
            this.autumnListBox.Size = new System.Drawing.Size(120, 95);
            this.autumnListBox.TabIndex = 8;
            // 
            // winter
            // 
            this.winter.Controls.Add(this.iAmDuplicateBox);
            this.winter.Controls.Add(this.myNameIsDuplicateBox);
            this.winter.Location = new System.Drawing.Point(4, 22);
            this.winter.Name = "winter";
            this.winter.Size = new System.Drawing.Size(440, 107);
            this.winter.TabIndex = 2;
            this.winter.Text = "Winter";
            this.winter.UseVisualStyleBackColor = true;
            // 
            // iAmDuplicateBox
            // 
            this.iAmDuplicateBox.Location = new System.Drawing.Point(164, 87);
            this.iAmDuplicateBox.Name = "iAmDuplicateBox";
            this.iAmDuplicateBox.Size = new System.Drawing.Size(100, 20);
            this.iAmDuplicateBox.TabIndex = 1;
            // 
            // myNameIsDuplicateBox
            // 
            this.myNameIsDuplicateBox.Location = new System.Drawing.Point(17, 87);
            this.myNameIsDuplicateBox.Name = "myNameIsDuplicateBox";
            this.myNameIsDuplicateBox.Size = new System.Drawing.Size(100, 20);
            this.myNameIsDuplicateBox.TabIndex = 0;
            // 
            // addNode
            // 
            this.addNode.Location = new System.Drawing.Point(140, 411);
            this.addNode.Name = "addNode";
            this.addNode.Size = new System.Drawing.Size(75, 23);
            this.addNode.TabIndex = 13;
            this.addNode.Text = "Add Node";
            this.addNode.UseVisualStyleBackColor = true;
            // 
            // showError
            // 
            this.showError.Location = new System.Drawing.Point(545, 80);
            this.showError.Name = "showError";
            this.showError.Size = new System.Drawing.Size(75, 23);
            this.showError.TabIndex = 14;
            this.showError.Text = "Show Error";
            this.showError.UseVisualStyleBackColor = true;
            // 
            // invisibleControlShower
            // 
            this.invisibleControlShower.Location = new System.Drawing.Point(848, 268);
            this.invisibleControlShower.Name = "invisibleControlShower";
            this.invisibleControlShower.Size = new System.Drawing.Size(75, 23);
            this.invisibleControlShower.TabIndex = 14;
            this.invisibleControlShower.Text = "Invisible Control Shower";
            this.invisibleControlShower.UseVisualStyleBackColor = true;
            // 
            // dynamicControl
            // 
            this.dynamicControl.AutoSize = true;
            this.dynamicControl.Location = new System.Drawing.Point(830, 312);
            this.dynamicControl.Name = "dynamicControl";
            this.dynamicControl.Size = new System.Drawing.Size(93, 13);
            this.dynamicControl.TabIndex = 15;
            this.dynamicControl.Text = "dynamically visible";
            this.dynamicControl.Visible = false;
            // 
            // checkBoxLaunchedModalWindow
            // 
            this.checkBoxLaunchedModalWindow.AutoSize = true;
            this.checkBoxLaunchedModalWindow.Location = new System.Drawing.Point(16, 486);
            this.checkBoxLaunchedModalWindow.Name = "checkBoxLaunchedModalWindow";
            this.checkBoxLaunchedModalWindow.Size = new System.Drawing.Size(84, 17);
            this.checkBoxLaunchedModalWindow.TabIndex = 16;
            this.checkBoxLaunchedModalWindow.Text = "Cheque Box";
            this.checkBoxLaunchedModalWindow.UseVisualStyleBackColor = true;
            // 
            // linkLaunchesModalWindow
            // 
            this.linkLaunchesModalWindow.AutoSize = true;
            this.linkLaunchesModalWindow.Location = new System.Drawing.Point(111, 490);
            this.linkLaunchesModalWindow.Name = "linkLaunchesModalWindow";
            this.linkLaunchesModalWindow.Size = new System.Drawing.Size(39, 13);
            this.linkLaunchesModalWindow.TabIndex = 17;
            this.linkLaunchesModalWindow.TabStop = true;
            this.linkLaunchesModalWindow.Text = "Linque";
            // 
            // treeViewLaunchesModal
            // 
            this.treeViewLaunchesModal.Location = new System.Drawing.Point(184, 565);
            this.treeViewLaunchesModal.Name = "treeViewLaunchesModal";
            treeNode5.Name = "childNode";
            treeNode5.Text = "Child";
            treeNode6.Name = "rootNode";
            treeNode6.Text = "Root";
            this.treeViewLaunchesModal.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6});
            this.treeViewLaunchesModal.Size = new System.Drawing.Size(199, 86);
            this.treeViewLaunchesModal.TabIndex = 18;
            // 
            // comboBoxLaunchingModalWindow
            // 
            this.comboBoxLaunchingModalWindow.FormattingEnabled = true;
            this.comboBoxLaunchingModalWindow.Items.AddRange(new object[] {
            "Arundhati Roy",
            "Noam Chomsky"});
            this.comboBoxLaunchingModalWindow.Location = new System.Drawing.Point(16, 520);
            this.comboBoxLaunchingModalWindow.Name = "comboBoxLaunchingModalWindow";
            this.comboBoxLaunchingModalWindow.Size = new System.Drawing.Size(121, 21);
            this.comboBoxLaunchingModalWindow.TabIndex = 19;
            // 
            // checkedListBoxLaunchingModalWindow
            // 
            this.checkedListBoxLaunchingModalWindow.FormattingEnabled = true;
            this.checkedListBoxLaunchingModalWindow.Items.AddRange(new object[] {
            "Bill Gates",
            "Narayan Murthy"});
            this.checkedListBoxLaunchingModalWindow.Location = new System.Drawing.Point(16, 565);
            this.checkedListBoxLaunchingModalWindow.Name = "checkedListBoxLaunchingModalWindow";
            this.checkedListBoxLaunchingModalWindow.Size = new System.Drawing.Size(120, 94);
            this.checkedListBoxLaunchingModalWindow.TabIndex = 20;
            // 
            // addDynamicControl
            // 
            this.addDynamicControl.Location = new System.Drawing.Point(945, 268);
            this.addDynamicControl.Name = "addDynamicControl";
            this.addDynamicControl.Size = new System.Drawing.Size(122, 23);
            this.addDynamicControl.TabIndex = 21;
            this.addDynamicControl.Text = "Add Dynamic Control";
            this.addDynamicControl.UseVisualStyleBackColor = true;
            // 
            // hasDynamicControl
            // 
            this.hasDynamicControl.Location = new System.Drawing.Point(945, 312);
            this.hasDynamicControl.Name = "hasDynamicControl";
            this.hasDynamicControl.Size = new System.Drawing.Size(141, 57);
            this.hasDynamicControl.TabIndex = 22;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStripLabel,
            this.toolStripProgressBar,
            this.toolStripDropDownButton,
            this.toolStripSplitButton,
            this.toolStripProgressBar2});
            this.statusStrip.Location = new System.Drawing.Point(0, 690);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1086, 22);
            this.statusStrip.TabIndex = 23;
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
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
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
            this.toolStripProgressBar2.Name = "toolStripProgressBar2";
            this.toolStripProgressBar2.Size = new System.Drawing.Size(100, 16);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(16, 152);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 23);
            this.progressBar.TabIndex = 24;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1086, 24);
            this.menuStrip1.TabIndex = 25;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.launchModalToolStripMenuItem,
            this.clickMeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // launchModalToolStripMenuItem
            // 
            this.launchModalToolStripMenuItem.Name = "launchModalToolStripMenuItem";
            this.launchModalToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.launchModalToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.launchModalToolStripMenuItem.Text = "LaunchModal";
            // 
            // clickMeToolStripMenuItem
            // 
            this.clickMeToolStripMenuItem.Name = "clickMeToolStripMenuItem";
            this.clickMeToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.clickMeToolStripMenuItem.Text = "Click Me";
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
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripLabel1,
            this.toolStripSplitButton1,
            this.toolStripDropDownButton1,
            this.toolStripComboBox1,
            this.toolStripTextBox1,
            this.toolStripProgressBar1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1086, 25);
            this.toolStrip1.TabIndex = 26;
            this.toolStrip1.Text = "toolStrip1";
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
            // toolStrip2
            // 
            this.toolStrip2.Location = new System.Drawing.Point(0, 49);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1086, 25);
            this.toolStrip2.TabIndex = 27;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // listView
            // 
            this.listView.Location = new System.Drawing.Point(562, 119);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(121, 97);
            this.listView.TabIndex = 28;
            this.listView.UseCompatibleStateImageBehavior = false;
            // 
            // multilineTextBox
            // 
            this.multilineTextBox.Location = new System.Drawing.Point(712, 392);
            this.multilineTextBox.Multiline = true;
            this.multilineTextBox.Name = "multilineTextBox";
            this.multilineTextBox.Size = new System.Drawing.Size(100, 47);
            this.multilineTextBox.TabIndex = 29;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(734, 119);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(135, 96);
            this.richTextBox1.TabIndex = 30;
            this.richTextBox1.Text = "";
            // 
            // image
            // 
            this.image.Image = ((System.Drawing.Image)(resources.GetObject("image.Image")));
            this.image.Location = new System.Drawing.Point(839, 413);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(47, 40);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image.TabIndex = 31;
            this.image.TabStop = false;
            // 
            // disableControls
            // 
            this.disableControls.Location = new System.Drawing.Point(908, 411);
            this.disableControls.Name = "disableControls";
            this.disableControls.Size = new System.Drawing.Size(106, 23);
            this.disableControls.TabIndex = 32;
            this.disableControls.Text = "Disable Controls";
            this.disableControls.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonInGroupBox);
            this.groupBox1.Location = new System.Drawing.Point(878, 486);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // buttonInGroupBox
            // 
            this.buttonInGroupBox.Location = new System.Drawing.Point(30, 43);
            this.buttonInGroupBox.Name = "buttonInGroupBox";
            this.buttonInGroupBox.Size = new System.Drawing.Size(142, 23);
            this.buttonInGroupBox.TabIndex = 1;
            this.buttonInGroupBox.Text = "Button In GroupBox";
            this.buttonInGroupBox.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxInsidePanel);
            this.panel1.Location = new System.Drawing.Point(878, 181);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(199, 69);
            this.panel1.TabIndex = 34;
            // 
            // textBoxInsidePanel
            // 
            this.textBoxInsidePanel.Location = new System.Drawing.Point(19, 15);
            this.textBoxInsidePanel.Name = "textBoxInsidePanel";
            this.textBoxInsidePanel.Size = new System.Drawing.Size(100, 20);
            this.textBoxInsidePanel.TabIndex = 0;
            // 
            // listViewForScenarioTest
            // 
            this.listViewForScenarioTest.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.invisible});
            this.listViewForScenarioTest.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewForScenarioTest.Location = new System.Drawing.Point(585, 438);
            this.listViewForScenarioTest.Name = "listViewForScenarioTest";
            this.listViewForScenarioTest.Size = new System.Drawing.Size(121, 63);
            this.listViewForScenarioTest.TabIndex = 35;
            this.listViewForScenarioTest.UseCompatibleStateImageBehavior = false;
            this.listViewForScenarioTest.View = System.Windows.Forms.View.Details;
            // 
            // buttonLaunchesMessageBox
            // 
            this.buttonLaunchesMessageBox.Location = new System.Drawing.Point(16, 181);
            this.buttonLaunchesMessageBox.Name = "buttonLaunchesMessageBox";
            this.buttonLaunchesMessageBox.Size = new System.Drawing.Size(134, 23);
            this.buttonLaunchesMessageBox.TabIndex = 36;
            this.buttonLaunchesMessageBox.Text = "Launch Message Box";
            this.buttonLaunchesMessageBox.UseVisualStyleBackColor = true;
            // 
            // panelWithText
            // 
            this.panelWithText.Location = new System.Drawing.Point(878, 603);
            this.panelWithText.Name = "panelWithText";
            this.panelWithText.Size = new System.Drawing.Size(106, 33);
            this.panelWithText.TabIndex = 37;
            // 
            // hiddenButton
            // 
            this.hiddenButton.Location = new System.Drawing.Point(412, 667);
            this.hiddenButton.Name = "hiddenButton";
            this.hiddenButton.Size = new System.Drawing.Size(110, 23);
            this.hiddenButton.TabIndex = 38;
            this.hiddenButton.Text = "Scroll To See Me";
            this.hiddenButton.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 1;
            this.numericUpDown1.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.numericUpDown1.Location = new System.Drawing.Point(31, 326);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 39;
            this.numericUpDown1.ThousandsSeparator = true;
            this.numericUpDown1.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // slider1
            // 
            this.slider1.LargeChange = 4;
            this.slider1.Location = new System.Drawing.Point(31, 373);
            this.slider1.Name = "slider1";
            this.slider1.Size = new System.Drawing.Size(104, 45);
            this.slider1.TabIndex = 40;
            this.slider1.Value = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1089, 650);
            this.Controls.Add(this.slider1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.hiddenButton);
            this.Controls.Add(this.panelWithText);
            this.Controls.Add(this.buttonLaunchesMessageBox);
            this.Controls.Add(this.listViewForScenarioTest);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.disableControls);
            this.Controls.Add(this.image);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.multilineTextBox);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.hasDynamicControl);
            this.Controls.Add(this.addDynamicControl);
            this.Controls.Add(this.checkedListBoxLaunchingModalWindow);
            this.Controls.Add(this.comboBoxLaunchingModalWindow);
            this.Controls.Add(this.treeViewLaunchesModal);
            this.Controls.Add(this.linkLaunchesModalWindow);
            this.Controls.Add(this.checkBoxLaunchedModalWindow);
            this.Controls.Add(this.showError);
            this.Controls.Add(this.dynamicControl);
            this.Controls.Add(this.invisibleControlShower);
            this.Controls.Add(this.addNode);
            this.Controls.Add(this.launchModal);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.listBoxWithVScrollBar);
            this.Controls.Add(this.people);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.ped);
            this.Controls.Add(this.seasons);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.komboBox);
            this.Controls.Add(this.chequedListBox);
            this.Controls.Add(this.linkLabel);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.chequeBox);
            this.Controls.Add(this.result);
            this.Controls.Add(this.buton);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.listBoxPopupMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.people)).EndInit();
            this.menuStripContainingMultilevelSubMenus.ResumeLayout(false);
            this.seasons.ResumeLayout(false);
            this.spring.ResumeLayout(false);
            this.spring.PerformLayout();
            this.Autumn.ResumeLayout(false);
            this.winter.ResumeLayout(false);
            this.winter.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buton;
        private System.Windows.Forms.Label result;
        private System.Windows.Forms.CheckBox chequeBox;
        private System.Windows.Forms.CheckedListBox chequedListBox;
        private System.Windows.Forms.ComboBox komboBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.LinkLabel linkLabel;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.TreeView ped;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.DataGridView people;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewComboBoxColumn country;
        private System.Windows.Forms.DataGridViewCheckBoxColumn alive;
        private System.Windows.Forms.DataGridViewButtonColumn display;
        private System.Windows.Forms.DataGridViewLinkColumn details;
        private System.Windows.Forms.ListBox listBoxWithVScrollBar;
        private System.Windows.Forms.Button launchModal;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabControl seasons;
        private System.Windows.Forms.TabPage spring;
        private System.Windows.Forms.TabPage Autumn;
        private System.Windows.Forms.ContextMenuStrip listBoxPopupMenu;
        private System.Windows.Forms.ToolStripMenuItem showFilmsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip menuStripContainingMultilevelSubMenus;
        private System.Windows.Forms.ToolStripMenuItem rootToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem level1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem level2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainToolStripMenuItem;
        private System.Windows.Forms.Button addNode;
        private System.Windows.Forms.Button springyButton;
        private System.Windows.Forms.TextBox springyTextBox;
        private System.Windows.Forms.ListBox autumnListBox;
        private System.Windows.Forms.Button showError;
        private System.Windows.Forms.Button invisibleControlShower;
        private System.Windows.Forms.Label dynamicControl;
        private System.Windows.Forms.TabPage winter;
        private System.Windows.Forms.TextBox iAmDuplicateBox;
        private System.Windows.Forms.TextBox myNameIsDuplicateBox;
        private System.Windows.Forms.CheckBox checkBoxLaunchedModalWindow;
        private System.Windows.Forms.LinkLabel linkLaunchesModalWindow;
        private System.Windows.Forms.TreeView treeViewLaunchesModal;
        private System.Windows.Forms.ComboBox comboBoxLaunchingModalWindow;
        private System.Windows.Forms.CheckedListBox checkedListBoxLaunchingModalWindow;
        private System.Windows.Forms.Button addDynamicControl;
        private System.Windows.Forms.Panel hasDynamicControl;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusStripLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem twoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oneToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton;
        private System.Windows.Forms.ToolStripMenuItem splitButtonToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem launchModalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clickMeToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.TextBox multilineTextBox;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.PictureBox image;
        private System.Windows.Forms.Button disableControls;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonInGroupBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxInsidePanel;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem;
        private System.Windows.Forms.ListView listViewForScenarioTest;
        private System.Windows.Forms.ColumnHeader invisible;
        private System.Windows.Forms.Button buttonLaunchesMessageBox;
        private System.Windows.Forms.Panel panelWithText;
        private System.Windows.Forms.Button hiddenButton;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TrackBar slider1;
    }
}