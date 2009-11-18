namespace SampleApplication
{
    partial class Dashboard
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
            this.createCustomer = new System.Windows.Forms.LinkLabel();
            this.searchCustomer = new System.Windows.Forms.LinkLabel();
            this.searchMovies = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // createCustomer
            // 
            this.createCustomer.AutoSize = true;
            this.createCustomer.Location = new System.Drawing.Point(30, 48);
            this.createCustomer.Name = "createCustomer";
            this.createCustomer.Size = new System.Drawing.Size(85, 13);
            this.createCustomer.TabIndex = 0;
            this.createCustomer.TabStop = true;
            this.createCustomer.Text = "Create Customer";
            // 
            // searchCustomer
            // 
            this.searchCustomer.AutoSize = true;
            this.searchCustomer.Location = new System.Drawing.Point(30, 81);
            this.searchCustomer.Name = "searchCustomer";
            this.searchCustomer.Size = new System.Drawing.Size(88, 13);
            this.searchCustomer.TabIndex = 1;
            this.searchCustomer.TabStop = true;
            this.searchCustomer.Text = "Search Customer";
            // 
            // searchMovies
            // 
            this.searchMovies.AutoSize = true;
            this.searchMovies.Location = new System.Drawing.Point(30, 123);
            this.searchMovies.Name = "searchMovies";
            this.searchMovies.Size = new System.Drawing.Size(78, 13);
            this.searchMovies.TabIndex = 8;
            this.searchMovies.TabStop = true;
            this.searchMovies.Text = "Search Movies";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 433);
            this.Controls.Add(this.searchMovies);
            this.Controls.Add(this.searchCustomer);
            this.Controls.Add(this.createCustomer);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel createCustomer;
        private System.Windows.Forms.LinkLabel searchCustomer;
        private System.Windows.Forms.LinkLabel searchMovies;
    }
}