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
            this.listControls1 = new WindowsFormsTestApplication.ListControls();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.inputControls1 = new WindowsFormsTestApplication.InputControls();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.GetMultipleButton = new System.Windows.Forms.Button();
            this.ButtonWithTooltip = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
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
            // listControls1
            // 
            this.listControls1.Location = new System.Drawing.Point(6, 19);
            this.listControls1.Name = "listControls1";
            this.listControls1.Size = new System.Drawing.Size(260, 204);
            this.listControls1.TabIndex = 0;
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
            // inputControls1
            // 
            this.inputControls1.Location = new System.Drawing.Point(7, 19);
            this.inputControls1.Name = "inputControls1";
            this.inputControls1.Size = new System.Drawing.Size(217, 181);
            this.inputControls1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.GetMultipleButton);
            this.groupBox3.Controls.Add(this.ButtonWithTooltip);
            this.groupBox3.Location = new System.Drawing.Point(532, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(207, 276);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Scenarios";
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
            this.ButtonWithTooltip.Text = "Button with Tooltip";
            this.toolTip1.SetToolTip(this.ButtonWithTooltip, "I have a tooltip");
            this.ButtonWithTooltip.UseVisualStyleBackColor = true;
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
            this.Text = "Form1";
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
    }
}

