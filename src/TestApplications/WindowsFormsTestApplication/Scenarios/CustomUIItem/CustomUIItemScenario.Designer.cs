namespace WindowsFormsTestApplication.Scenarios.CustomUIItem
{
    partial class CustomUIItemScenario
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
            this.DateOfBirth = new WindowsFormsTestApplication.Scenarios.CustomUIItem.MyDateControl();
            this.SuspendLayout();
            // 
            // DateOfBirth
            // 
            this.DateOfBirth.Location = new System.Drawing.Point(13, 13);
            this.DateOfBirth.Name = "DateOfBirth";
            this.DateOfBirth.Size = new System.Drawing.Size(201, 49);
            this.DateOfBirth.TabIndex = 0;
            // 
            // CustomUIItemScenario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 276);
            this.Controls.Add(this.DateOfBirth);
            this.Name = "CustomUIItemScenario";
            this.Text = "CustomUIItemScenario";
            this.ResumeLayout(false);

        }

        #endregion

        private MyDateControl DateOfBirth;
    }
}