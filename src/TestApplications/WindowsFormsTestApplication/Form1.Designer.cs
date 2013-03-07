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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listControls1 = new WindowsFormsTestApplication.ListControls();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.inputControls1 = new WindowsFormsTestApplication.InputControls();
            this.DataGridControl = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridControl)).BeginInit();
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
            // DataGridControl
            // 
            this.DataGridControl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridControl.Location = new System.Drawing.Point(12, 294);
            this.DataGridControl.Name = "DataGridControl";
            this.DataGridControl.Size = new System.Drawing.Size(514, 177);
            this.DataGridControl.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 483);
            this.Controls.Add(this.DataGridControl);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ListControls listControls1;
        private System.Windows.Forms.GroupBox groupBox2;
        private InputControls inputControls1;
        private System.Windows.Forms.DataGridView DataGridControl;
    }
}

