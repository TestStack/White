namespace WinFormsTestApp
{
    partial class ListViewScenarios
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
            this.listViewWithHorizontalScroll = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // listViewWithHorizontalScroll
            // 
            this.listViewWithHorizontalScroll.Location = new System.Drawing.Point(69, 74);
            this.listViewWithHorizontalScroll.Name = "listViewWithHorizontalScroll";
            this.listViewWithHorizontalScroll.Size = new System.Drawing.Size(121, 97);
            this.listViewWithHorizontalScroll.TabIndex = 0;
            this.listViewWithHorizontalScroll.UseCompatibleStateImageBehavior = false;
            // 
            // ListViewScenarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.listViewWithHorizontalScroll);
            this.Name = "ListViewScenarios";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewWithHorizontalScroll;
    }
}