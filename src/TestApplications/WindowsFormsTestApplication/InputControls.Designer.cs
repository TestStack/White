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
            this.label1 = new System.Windows.Forms.Label();
            this.CheckBox = new System.Windows.Forms.CheckBox();
            this.TextBox = new System.Windows.Forms.TextBox();
            this.MultiLineTextBox = new System.Windows.Forms.TextBox();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.UnmaskPasswordButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DatePicker
            // 
            this.DatePicker.Location = new System.Drawing.Point(3, 29);
            this.DatePicker.Name = "DatePicker";
            this.DatePicker.Size = new System.Drawing.Size(200, 20);
            this.DatePicker.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "DateTimePicker";
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
            // InputControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UnmaskPasswordButton);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.MultiLineTextBox);
            this.Controls.Add(this.TextBox);
            this.Controls.Add(this.CheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DatePicker);
            this.Name = "InputControls";
            this.Size = new System.Drawing.Size(319, 292);
            this.EnabledChanged += new System.EventHandler(this.InputControls_EnabledChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DatePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CheckBox;
        private System.Windows.Forms.TextBox TextBox;
        private System.Windows.Forms.TextBox MultiLineTextBox;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.Button UnmaskPasswordButton;
    }
}
