namespace WindowsFormsTestApplication
{
    partial class DragAndDropTestWindow
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
            this.TextBox = new System.Windows.Forms.TextBox();
            this.Button = new System.Windows.Forms.Button();
            this.DragDropResults = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TextBox
            // 
            this.TextBox.Location = new System.Drawing.Point(13, 13);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(259, 20);
            this.TextBox.TabIndex = 0;
            // 
            // Button
            // 
            this.Button.Location = new System.Drawing.Point(13, 40);
            this.Button.Name = "Button";
            this.Button.Size = new System.Drawing.Size(259, 23);
            this.Button.TabIndex = 1;
            this.Button.Text = "button";
            this.Button.UseVisualStyleBackColor = true;
            this.Button.DragDrop += new System.Windows.Forms.DragEventHandler(this.Button_DragDrop);
            // 
            // DragDropResults
            // 
            this.DragDropResults.AutoSize = true;
            this.DragDropResults.Location = new System.Drawing.Point(13, 70);
            this.DragDropResults.Name = "DragDropResults";
            this.DragDropResults.Size = new System.Drawing.Size(35, 13);
            this.DragDropResults.TabIndex = 2;
            this.DragDropResults.Text = "label1";
            // 
            // DragAndDropTestWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.DragDropResults);
            this.Controls.Add(this.Button);
            this.Controls.Add(this.TextBox);
            this.Name = "DragAndDropTestWindow";
            this.Text = "DragAndDropTestWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBox;
        private System.Windows.Forms.Button Button;
        private System.Windows.Forms.Label DragDropResults;
    }
}