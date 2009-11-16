namespace Recorder.Controls
{
    partial class ApplicationsControl
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
            this.applications = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // applications
            // 
            this.applications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.applications.FormattingEnabled = true;
            this.applications.Location = new System.Drawing.Point(0, 0);
            this.applications.Name = "applications";
            this.applications.Size = new System.Drawing.Size(443, 264);
            this.applications.TabIndex = 0;
            // 
            // ApplicationsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.applications);
            this.Name = "ApplicationsControl";
            this.Size = new System.Drawing.Size(443, 275);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox applications;

    }
}
