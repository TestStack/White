namespace WindowsFormsTestApplication
{
    partial class ListControls
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AComboBox = new System.Windows.Forms.ComboBox();
            this.CheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.EditableComboBox = new System.Windows.Forms.ComboBox();
            this.ListBoxWithVScrollBar = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "CheckedListBoxTests";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "EditableComboBoxTests";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "ComboBoxTests";
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
            this.AComboBox.Location = new System.Drawing.Point(2, 29);
            this.AComboBox.Name = "AComboBox";
            this.AComboBox.Size = new System.Drawing.Size(121, 21);
            this.AComboBox.TabIndex = 6;
            // 
            // CheckedListBox
            // 
            this.CheckedListBox.FormattingEnabled = true;
            this.CheckedListBox.Items.AddRange(new object[] {
            "Item1",
            "Item2",
            "Item3",
            "Item4"});
            this.CheckedListBox.Location = new System.Drawing.Point(2, 91);
            this.CheckedListBox.Name = "CheckedListBox";
            this.CheckedListBox.Size = new System.Drawing.Size(120, 94);
            this.CheckedListBox.TabIndex = 8;
            // 
            // EditableComboBox
            // 
            this.EditableComboBox.FormattingEnabled = true;
            this.EditableComboBox.Items.AddRange(new object[] {
            "Test",
            "Test2",
            "Test3",
            "Test4"});
            this.EditableComboBox.Location = new System.Drawing.Point(129, 29);
            this.EditableComboBox.Name = "EditableComboBox";
            this.EditableComboBox.Size = new System.Drawing.Size(121, 21);
            this.EditableComboBox.TabIndex = 7;
            // 
            // ListBoxWithVScrollBar
            // 
            this.ListBoxWithVScrollBar.FormattingEnabled = true;
            this.ListBoxWithVScrollBar.Items.AddRange(new object[] {
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
            this.ListBoxWithVScrollBar.Location = new System.Drawing.Point(130, 91);
            this.ListBoxWithVScrollBar.Name = "ListBoxWithVScrollBar";
            this.ListBoxWithVScrollBar.Size = new System.Drawing.Size(120, 95);
            this.ListBoxWithVScrollBar.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(127, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "ListBoxWithVerticalScrollbars";
            // 
            // ListControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ListBoxWithVScrollBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AComboBox);
            this.Controls.Add(this.CheckedListBox);
            this.Controls.Add(this.EditableComboBox);
            this.Name = "ListControls";
            this.Size = new System.Drawing.Size(571, 326);
            this.EnabledChanged += new System.EventHandler(this.ListControls_EnabledChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox AComboBox;
        private System.Windows.Forms.CheckedListBox CheckedListBox;
        private System.Windows.Forms.ComboBox EditableComboBox;
        private System.Windows.Forms.ListBox ListBoxWithVScrollBar;
        private System.Windows.Forms.Label label4;
    }
}
