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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DragDropScenario = new System.Windows.Forms.Button();
            this.OpenFormWithoutScrollAndItemOutside = new System.Windows.Forms.Button();
            this.DisableControls = new System.Windows.Forms.Button();
            this.OpenListView = new System.Windows.Forms.Button();
            this.GetMultipleButton = new System.Windows.Forms.Button();
            this.ButtonWithTooltip = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.CustomUIItemScenario = new System.Windows.Forms.Button();
            this.inputControls1 = new WindowsFormsTestApplication.InputControls();
            this.listControls1 = new WindowsFormsTestApplication.ListControls();
            this.OpenMessageBox = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listControls1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 276);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List Controls";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.inputControls1);
            this.groupBox2.Location = new System.Drawing.Point(296, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(230, 276);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input Controls";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.OpenMessageBox);
            this.groupBox3.Controls.Add(this.CustomUIItemScenario);
            this.groupBox3.Controls.Add(this.DragDropScenario);
            this.groupBox3.Controls.Add(this.OpenFormWithoutScrollAndItemOutside);
            this.groupBox3.Controls.Add(this.DisableControls);
            this.groupBox3.Controls.Add(this.OpenListView);
            this.groupBox3.Controls.Add(this.GetMultipleButton);
            this.groupBox3.Controls.Add(this.ButtonWithTooltip);
            this.groupBox3.Location = new System.Drawing.Point(532, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(207, 276);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Scenarios";
            // 
            // DragDropScenario
            // 
            this.DragDropScenario.Location = new System.Drawing.Point(7, 169);
            this.DragDropScenario.Name = "DragDropScenario";
            this.DragDropScenario.Size = new System.Drawing.Size(194, 23);
            this.DragDropScenario.TabIndex = 5;
            this.DragDropScenario.Text = "Drag Drop Scenario";
            this.DragDropScenario.UseVisualStyleBackColor = true;
            this.DragDropScenario.Click += new System.EventHandler(this.DragDropScenario_Click);
            // 
            // OpenFormWithoutScrollAndItemOutside
            // 
            this.OpenFormWithoutScrollAndItemOutside.Location = new System.Drawing.Point(7, 139);
            this.OpenFormWithoutScrollAndItemOutside.Name = "OpenFormWithoutScrollAndItemOutside";
            this.OpenFormWithoutScrollAndItemOutside.Size = new System.Drawing.Size(194, 23);
            this.OpenFormWithoutScrollAndItemOutside.TabIndex = 4;
            this.OpenFormWithoutScrollAndItemOutside.Text = "FormWithoutScrollAndControlOutside";
            this.OpenFormWithoutScrollAndItemOutside.UseVisualStyleBackColor = true;
            this.OpenFormWithoutScrollAndItemOutside.Click += new System.EventHandler(this.OpenFormWithoutScrollAndControlOutside_Click);
            // 
            // DisableControls
            // 
            this.DisableControls.Location = new System.Drawing.Point(7, 109);
            this.DisableControls.Name = "DisableControls";
            this.DisableControls.Size = new System.Drawing.Size(194, 23);
            this.DisableControls.TabIndex = 3;
            this.DisableControls.Text = "Disable Controls";
            this.DisableControls.UseVisualStyleBackColor = true;
            this.DisableControls.Click += new System.EventHandler(this.DisableControls_Click);
            // 
            // OpenListView
            // 
            this.OpenListView.Location = new System.Drawing.Point(7, 79);
            this.OpenListView.Name = "OpenListView";
            this.OpenListView.Size = new System.Drawing.Size(194, 23);
            this.OpenListView.TabIndex = 2;
            this.OpenListView.Text = "ListView Control";
            this.OpenListView.UseVisualStyleBackColor = true;
            this.OpenListView.Click += new System.EventHandler(this.OpenListView_Click);
            // 
            // GetMultipleButton
            // 
            this.GetMultipleButton.Location = new System.Drawing.Point(7, 49);
            this.GetMultipleButton.Name = "GetMultipleButton";
            this.GetMultipleButton.Size = new System.Drawing.Size(194, 23);
            this.GetMultipleButton.TabIndex = 1;
            this.GetMultipleButton.Text = "Get Multiple";
            this.GetMultipleButton.UseVisualStyleBackColor = true;
            this.GetMultipleButton.Click += new System.EventHandler(this.GetMultiple_Click);
            // 
            // ButtonWithTooltip
            // 
            this.ButtonWithTooltip.Location = new System.Drawing.Point(6, 19);
            this.ButtonWithTooltip.Name = "ButtonWithTooltip";
            this.ButtonWithTooltip.Size = new System.Drawing.Size(195, 23);
            this.ButtonWithTooltip.TabIndex = 0;
            this.ButtonWithTooltip.Text = "&Button with Tooltip";
            this.toolTip1.SetToolTip(this.ButtonWithTooltip, "I have a tooltip");
            this.ButtonWithTooltip.UseVisualStyleBackColor = true;
            this.ButtonWithTooltip.Click += new System.EventHandler(this.ButtonWithTooltip_Click);
            this.ButtonWithTooltip.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ButtonWithTooltip_MouseClick);
            this.ButtonWithTooltip.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonWithTooltip_MouseUp);
            // 
            // CustomUIItemScenario
            // 
            this.CustomUIItemScenario.Location = new System.Drawing.Point(6, 198);
            this.CustomUIItemScenario.Name = "CustomUIItemScenario";
            this.CustomUIItemScenario.Size = new System.Drawing.Size(194, 23);
            this.CustomUIItemScenario.TabIndex = 6;
            this.CustomUIItemScenario.Text = "Custom UI Item";
            this.CustomUIItemScenario.UseVisualStyleBackColor = true;
            this.CustomUIItemScenario.Click += new System.EventHandler(this.CustomUIItemScenario_Click);
            // 
            // inputControls1
            // 
            this.inputControls1.Location = new System.Drawing.Point(7, 19);
            this.inputControls1.Name = "inputControls1";
            this.inputControls1.Size = new System.Drawing.Size(217, 251);
            this.inputControls1.TabIndex = 0;
            // 
            // listControls1
            // 
            this.listControls1.Location = new System.Drawing.Point(6, 19);
            this.listControls1.Name = "listControls1";
            this.listControls1.Size = new System.Drawing.Size(260, 204);
            this.listControls1.TabIndex = 0;
            // 
            // OpenMessageBox
            // 
            this.OpenMessageBox.Location = new System.Drawing.Point(7, 228);
            this.OpenMessageBox.Name = "OpenMessageBox";
            this.OpenMessageBox.Size = new System.Drawing.Size(193, 23);
            this.OpenMessageBox.TabIndex = 7;
            this.OpenMessageBox.Text = "Open Message Box";
            this.OpenMessageBox.UseVisualStyleBackColor = true;
            this.OpenMessageBox.Click += new System.EventHandler(this.OpenMessageBox_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 405);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainWindow";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ListControls listControls1;
        private System.Windows.Forms.GroupBox groupBox2;
        private InputControls inputControls1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button ButtonWithTooltip;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button GetMultipleButton;
        private System.Windows.Forms.Button OpenListView;
        private System.Windows.Forms.Button DisableControls;
        private System.Windows.Forms.Button OpenFormWithoutScrollAndItemOutside;
        private System.Windows.Forms.Button DragDropScenario;
        private System.Windows.Forms.Button CustomUIItemScenario;
        private System.Windows.Forms.Button OpenMessageBox;
    }
}

