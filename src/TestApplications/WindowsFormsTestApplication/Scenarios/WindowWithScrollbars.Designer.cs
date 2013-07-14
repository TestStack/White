namespace WindowsFormsTestApplication.Scenarios
{
    partial class WindowWithScrollbars
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
            this.HiddenButton = new System.Windows.Forms.Button();
            this.ButtonBackUpTop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HiddenButton
            // 
            this.HiddenButton.Location = new System.Drawing.Point(396, 319);
            this.HiddenButton.Name = "HiddenButton";
            this.HiddenButton.Size = new System.Drawing.Size(129, 23);
            this.HiddenButton.TabIndex = 0;
            this.HiddenButton.Text = "Scroll To See Me";
            this.HiddenButton.UseVisualStyleBackColor = true;
            this.HiddenButton.Click += new System.EventHandler(this.HiddenButton_Click);
            // 
            // ButtonBackUpTop
            // 
            this.ButtonBackUpTop.Location = new System.Drawing.Point(13, 13);
            this.ButtonBackUpTop.Name = "ButtonBackUpTop";
            this.ButtonBackUpTop.Size = new System.Drawing.Size(109, 23);
            this.ButtonBackUpTop.TabIndex = 1;
            this.ButtonBackUpTop.Text = "Back Up Top";
            this.ButtonBackUpTop.UseVisualStyleBackColor = true;
            this.ButtonBackUpTop.Click += new System.EventHandler(this.ButtonBackUpTop_Click);
            // 
            // WindowWithScrollbars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(368, 177);
            this.Controls.Add(this.ButtonBackUpTop);
            this.Controls.Add(this.HiddenButton);
            this.Name = "WindowWithScrollbars";
            this.Text = "WindowWithScrollbars";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button HiddenButton;
        private System.Windows.Forms.Button ButtonBackUpTop;
    }
}