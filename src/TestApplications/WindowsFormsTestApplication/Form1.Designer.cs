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
            this.CheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
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
            this.AComboBox.Location = new System.Drawing.Point(6, 37);
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
            this.EditableComboBox.Location = new System.Drawing.Point(133, 37);
            this.EditableComboBox.Name = "EditableComboBox";
            this.EditableComboBox.Size = new System.Drawing.Size(121, 21);
            this.EditableComboBox.TabIndex = 1;
            // 
            // CheckedListBox
            // 
            this.CheckedListBox.FormattingEnabled = true;
            this.CheckedListBox.Items.AddRange(new object[] {
            "Item1",
            "Item2",
            "Item3",
            "Item4"});
            this.CheckedListBox.Location = new System.Drawing.Point(6, 99);
            this.CheckedListBox.Name = "CheckedListBox";
            this.CheckedListBox.Size = new System.Drawing.Size(120, 94);
            this.CheckedListBox.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.AComboBox);
            this.groupBox1.Controls.Add(this.CheckedListBox);
            this.groupBox1.Controls.Add(this.EditableComboBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 276);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List Controls";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "ComboBoxTests";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "EditableComboBoxTests";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "CheckedListBoxTests";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 405);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox AComboBox;
        private System.Windows.Forms.ComboBox EditableComboBox;
        private System.Windows.Forms.CheckedListBox CheckedListBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

