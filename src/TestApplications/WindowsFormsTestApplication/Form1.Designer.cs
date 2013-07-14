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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ScenariosPane = new System.Windows.Forms.GroupBox();
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.ListControlsTab = new System.Windows.Forms.TabPage();
            this.InputControlsTab = new System.Windows.Forms.TabPage();
            this.OtherControlsTab = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TextBoxInsidePanel = new System.Windows.Forms.TextBox();
            this.ToolStrip2 = new System.Windows.Forms.ToolStrip();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.ShowHiddenTextBox = new System.Windows.Forms.Button();
            this.AddTextBox = new System.Windows.Forms.Button();
            this.AddTextBoxPanel = new System.Windows.Forms.Panel();
            this.HiddenTextBox = new System.Windows.Forms.TextBox();
            this.listControls1 = new WindowsFormsTestApplication.ListControls();
            this.inputControls1 = new WindowsFormsTestApplication.InputControls();
            this.ScenariosPane.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.ListControlsTab.SuspendLayout();
            this.InputControlsTab.SuspendLayout();
            this.OtherControlsTab.SuspendLayout();
            this.panel1.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScenariosPane
            // 
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
            this.ScenariosPane.Location = new System.Drawing.Point(716, 60);
            this.ScenariosPane.Name = "ScenariosPane";
            this.ScenariosPane.Size = new System.Drawing.Size(254, 333);
            this.ScenariosPane.TabIndex = 5;
            this.ScenariosPane.TabStop = false;
            this.ScenariosPane.Text = "Scenarios";
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.ListControlsTab);
            this.tabControl1.Controls.Add(this.InputControlsTab);
            this.tabControl1.Controls.Add(this.OtherControlsTab);
            this.tabControl1.Location = new System.Drawing.Point(13, 60);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(697, 333);
            this.tabControl1.TabIndex = 7;
            // 
            // ListControlsTab
            // 
            this.ListControlsTab.Controls.Add(this.listControls1);
            this.ListControlsTab.Location = new System.Drawing.Point(4, 22);
            this.ListControlsTab.Name = "ListControlsTab";
            this.ListControlsTab.Padding = new System.Windows.Forms.Padding(3);
            this.ListControlsTab.Size = new System.Drawing.Size(689, 307);
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
            this.InputControlsTab.Size = new System.Drawing.Size(689, 307);
            this.InputControlsTab.TabIndex = 1;
            this.InputControlsTab.Text = "Input Controls";
            this.InputControlsTab.UseVisualStyleBackColor = true;
            // 
            // OtherControlsTab
            // 
            this.OtherControlsTab.Controls.Add(this.HiddenTextBox);
            this.OtherControlsTab.Controls.Add(this.AddTextBoxPanel);
            this.OtherControlsTab.Controls.Add(this.AddTextBox);
            this.OtherControlsTab.Controls.Add(this.ShowHiddenTextBox);
            this.OtherControlsTab.Controls.Add(this.panel1);
            this.OtherControlsTab.Controls.Add(this.ProgressBar);
            this.OtherControlsTab.Controls.Add(this.LinkLabel);
            this.OtherControlsTab.Location = new System.Drawing.Point(4, 22);
            this.OtherControlsTab.Name = "OtherControlsTab";
            this.OtherControlsTab.Size = new System.Drawing.Size(689, 307);
            this.OtherControlsTab.TabIndex = 2;
            this.OtherControlsTab.Text = "Other Controls";
            this.OtherControlsTab.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TextBoxInsidePanel);
            this.panel1.Location = new System.Drawing.Point(15, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(168, 50);
            this.panel1.TabIndex = 9;
            // 
            // TextBoxInsidePanel
            // 
            this.TextBoxInsidePanel.Location = new System.Drawing.Point(13, 17);
            this.TextBoxInsidePanel.Name = "TextBoxInsidePanel";
            this.TextBoxInsidePanel.Size = new System.Drawing.Size(77, 20);
            this.TextBoxInsidePanel.TabIndex = 0;
            // 
            // ToolStrip2
            // 
            this.ToolStrip2.Location = new System.Drawing.Point(0, 25);
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
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
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
            // AddTextBoxPanel
            // 
            this.AddTextBoxPanel.Location = new System.Drawing.Point(114, 126);
            this.AddTextBoxPanel.Name = "AddTextBoxPanel";
            this.AddTextBoxPanel.Size = new System.Drawing.Size(238, 29);
            this.AddTextBoxPanel.TabIndex = 12;
            // 
            // HiddenTextBox
            // 
            this.HiddenTextBox.Location = new System.Drawing.Point(160, 161);
            this.HiddenTextBox.Name = "HiddenTextBox";
            this.HiddenTextBox.Size = new System.Drawing.Size(100, 20);
            this.HiddenTextBox.TabIndex = 13;
            this.HiddenTextBox.Visible = false;
            // 
            // listControls1
            // 
            this.listControls1.Location = new System.Drawing.Point(20, 3);
            this.listControls1.Name = "listControls1";
            this.listControls1.Size = new System.Drawing.Size(260, 204);
            this.listControls1.TabIndex = 0;
            // 
            // inputControls1
            // 
            this.inputControls1.Location = new System.Drawing.Point(6, 6);
            this.inputControls1.Name = "inputControls1";
            this.inputControls1.Size = new System.Drawing.Size(217, 343);
            this.inputControls1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 405);
            this.Controls.Add(this.ToolStrip2);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ScenariosPane);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainWindow";
            this.ScenariosPane.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ListControlsTab.ResumeLayout(false);
            this.InputControlsTab.ResumeLayout(false);
            this.OtherControlsTab.ResumeLayout(false);
            this.OtherControlsTab.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage ListControlsTab;
        private System.Windows.Forms.TabPage InputControlsTab;
        private System.Windows.Forms.TabPage OtherControlsTab;
        private System.Windows.Forms.Panel panel1;
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
    }
}

