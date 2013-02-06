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
            this.AComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // AComboBox
            // 
            this.AComboBox.FormattingEnabled = true;
            this.AComboBox.Items.AddRange(new object[] {
            "Test1",
            "Test2"});
            this.AComboBox.Location = new System.Drawing.Point(12, 12);
            this.AComboBox.Name = "AComboBox";
            this.AComboBox.Size = new System.Drawing.Size(121, 21);
            this.AComboBox.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 405);
            this.Controls.Add(this.AComboBox);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox AComboBox;
    }
}

