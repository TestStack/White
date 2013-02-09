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
            this.EditableComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // AComboBox
            // 
            this.AComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AComboBox.FormattingEnabled = true;
            this.AComboBox.Items.AddRange(new object[] {
            "Test",
            "Test2",
            "Test3",
            "Test4",
            "Test5",
            "Test6",
            "Test7",
            "Test8",
            "Test9",
            "Test10",
            "Test11",
            "Test12",
            "Test13",
            "Test14",
            "Test15",
            "Test16",
            "Test17",
            "Test18",
            "Test19",
            "Test20",
            "ReallyReallyReallyLongTextHere"});
            this.AComboBox.Location = new System.Drawing.Point(12, 12);
            this.AComboBox.Name = "AComboBox";
            this.AComboBox.Size = new System.Drawing.Size(121, 21);
            this.AComboBox.TabIndex = 0;
            // 
            // EditableComboBox
            // 
            this.EditableComboBox.FormattingEnabled = true;
            this.EditableComboBox.Items.AddRange(new object[] {
            "Test",
            "Test2",
            "Test3",
            "Test4"});
            this.EditableComboBox.Location = new System.Drawing.Point(139, 12);
            this.EditableComboBox.Name = "EditableComboBox";
            this.EditableComboBox.Size = new System.Drawing.Size(121, 21);
            this.EditableComboBox.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 405);
            this.Controls.Add(this.EditableComboBox);
            this.Controls.Add(this.AComboBox);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox AComboBox;
        private System.Windows.Forms.ComboBox EditableComboBox;
    }
}

