namespace SampleApplication
{
    partial class CreateCustomerStep2
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
            this.phoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.phoneNumberLabel = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // phoneNumberTextBox
            // 
            this.phoneNumberTextBox.Location = new System.Drawing.Point(100, 14);
            this.phoneNumberTextBox.Name = "phoneNumberTextBox";
            this.phoneNumberTextBox.Size = new System.Drawing.Size(100, 20);
            this.phoneNumberTextBox.TabIndex = 0;
            // 
            // phoneNumberLabel
            // 
            this.phoneNumberLabel.AutoSize = true;
            this.phoneNumberLabel.Location = new System.Drawing.Point(12, 17);
            this.phoneNumberLabel.Name = "phoneNumberLabel";
            this.phoneNumberLabel.Size = new System.Drawing.Size(78, 13);
            this.phoneNumberLabel.TabIndex = 1;
            this.phoneNumberLabel.Text = "Phone Number";
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(29, 78);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 1;
            this.submitButton.Text = "&Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            // 
            // CreateCustomerStep2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.phoneNumberLabel);
            this.Controls.Add(this.phoneNumberTextBox);
            this.Name = "CreateCustomerStep2";
            this.Text = "Create Customer Step2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox phoneNumberTextBox;
        private System.Windows.Forms.Label phoneNumberLabel;
        private System.Windows.Forms.Button submitButton;
    }
}