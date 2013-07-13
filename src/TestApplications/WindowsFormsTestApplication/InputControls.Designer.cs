namespace WindowsFormsTestApplication
{
    partial class InputControls
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
            this.DatePicker = new System.Windows.Forms.DateTimePicker();
            this.DateTimePickerLabel = new System.Windows.Forms.Label();
            this.CheckBox = new System.Windows.Forms.CheckBox();
            this.TextBox = new System.Windows.Forms.TextBox();
            this.MultiLineTextBox = new System.Windows.Forms.TextBox();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.UnmaskPasswordButton = new System.Windows.Forms.Button();
            this.RadioButton1 = new System.Windows.Forms.RadioButton();
            this.RadioButton2 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // DatePicker
            // 
            this.DatePicker.Location = new System.Drawing.Point(3, 29);
            this.DatePicker.Name = "DatePicker";
            this.DatePicker.Size = new System.Drawing.Size(200, 20);
            this.DatePicker.TabIndex = 0;
            // 
            // DateTimePickerLabel
            // 
            this.DateTimePickerLabel.AutoSize = true;
            this.DateTimePickerLabel.Location = new System.Drawing.Point(4, 10);
            this.DateTimePickerLabel.Name = "DateTimePickerLabel";
            this.DateTimePickerLabel.Size = new System.Drawing.Size(83, 13);
            this.DateTimePickerLabel.TabIndex = 1;
            this.DateTimePickerLabel.Text = "DateTimePicker";
            // 
            // CheckBox
            // 
            this.CheckBox.AutoSize = true;
            this.CheckBox.Location = new System.Drawing.Point(4, 56);
            this.CheckBox.Name = "CheckBox";
            this.CheckBox.Size = new System.Drawing.Size(80, 17);
            this.CheckBox.TabIndex = 2;
            this.CheckBox.Text = "checkBox1";
            this.CheckBox.UseVisualStyleBackColor = true;
            // 
            // TextBox
            // 
            this.TextBox.AutoCompleteCustomSource.AddRange(new string[] {
            "hi",
            "hello"});
            this.TextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.TextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TextBox.Location = new System.Drawing.Point(7, 80);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(196, 20);
            this.TextBox.TabIndex = 3;
            this.TextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // MultiLineTextBox
            // 
            this.MultiLineTextBox.Location = new System.Drawing.Point(7, 107);
            this.MultiLineTextBox.Multiline = true;
            this.MultiLineTextBox.Name = "MultiLineTextBox";
            this.MultiLineTextBox.Size = new System.Drawing.Size(196, 64);
            this.MultiLineTextBox.TabIndex = 4;
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(7, 178);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.Size = new System.Drawing.Size(115, 20);
            this.PasswordBox.TabIndex = 5;
            this.PasswordBox.UseSystemPasswordChar = true;
            // 
            // UnmaskPasswordButton
            // 
            this.UnmaskPasswordButton.Location = new System.Drawing.Point(128, 178);
            this.UnmaskPasswordButton.Name = "UnmaskPasswordButton";
            this.UnmaskPasswordButton.Size = new System.Drawing.Size(75, 23);
            this.UnmaskPasswordButton.TabIndex = 6;
            this.UnmaskPasswordButton.Text = "Unmask";
            this.UnmaskPasswordButton.UseVisualStyleBackColor = true;
            this.UnmaskPasswordButton.Click += new System.EventHandler(this.UnmaskPasswordButton_Click);
            // 
            // RadioButton1
            // 
            this.RadioButton1.AutoSize = true;
            this.RadioButton1.Location = new System.Drawing.Point(7, 205);
            this.RadioButton1.Name = "RadioButton1";
            this.RadioButton1.Size = new System.Drawing.Size(85, 17);
            this.RadioButton1.TabIndex = 7;
            this.RadioButton1.TabStop = true;
            this.RadioButton1.Text = "radioButton1";
            this.RadioButton1.UseVisualStyleBackColor = true;
            // 
            // RadioButton2
            // 
            this.RadioButton2.AutoSize = true;
            this.RadioButton2.Location = new System.Drawing.Point(99, 205);
            this.RadioButton2.Name = "RadioButton2";
            this.RadioButton2.Size = new System.Drawing.Size(85, 17);
            this.RadioButton2.TabIndex = 8;
            this.RadioButton2.TabStop = true;
            this.RadioButton2.Text = "radioButton2";
            this.RadioButton2.UseVisualStyleBackColor = true;
            // 
            // InputControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RadioButton2);
            this.Controls.Add(this.RadioButton1);
            this.Controls.Add(this.UnmaskPasswordButton);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.MultiLineTextBox);
            this.Controls.Add(this.TextBox);
            this.Controls.Add(this.CheckBox);
            this.Controls.Add(this.DateTimePickerLabel);
            this.Controls.Add(this.DatePicker);
            this.Name = "InputControls";
            this.Size = new System.Drawing.Size(319, 292);
            this.EnabledChanged += new System.EventHandler(this.InputControls_EnabledChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DatePicker;
        private System.Windows.Forms.Label DateTimePickerLabel;
        private System.Windows.Forms.CheckBox CheckBox;
        private System.Windows.Forms.TextBox TextBox;
        private System.Windows.Forms.TextBox MultiLineTextBox;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.Button UnmaskPasswordButton;
        private System.Windows.Forms.RadioButton RadioButton1;
        private System.Windows.Forms.RadioButton RadioButton2;
    }
}
