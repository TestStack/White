namespace WindowsFormsTestApplication.Scenarios.CustomUIItem
{
    partial class MyDateControl
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
            this.Day = new System.Windows.Forms.TextBox();
            this.Month = new System.Windows.Forms.TextBox();
            this.Year = new System.Windows.Forms.TextBox();
            this.dayLabel = new System.Windows.Forms.Label();
            this.monthLabel = new System.Windows.Forms.Label();
            this.yearLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Day
            // 
            this.Day.Location = new System.Drawing.Point(36, 15);
            this.Day.Name = "Day";
            this.Day.Size = new System.Drawing.Size(31, 20);
            this.Day.TabIndex = 0;
            // 
            // Month
            // 
            this.Month.Location = new System.Drawing.Point(102, 15);
            this.Month.Name = "Month";
            this.Month.Size = new System.Drawing.Size(31, 20);
            this.Month.TabIndex = 1;
            // 
            // Year
            // 
            this.Year.Location = new System.Drawing.Point(164, 15);
            this.Year.Name = "Year";
            this.Year.Size = new System.Drawing.Size(31, 20);
            this.Year.TabIndex = 2;
            // 
            // dayLabel
            // 
            this.dayLabel.AutoSize = true;
            this.dayLabel.Location = new System.Drawing.Point(10, 18);
            this.dayLabel.Name = "dayLabel";
            this.dayLabel.Size = new System.Drawing.Size(19, 13);
            this.dayLabel.TabIndex = 3;
            this.dayLabel.Text = "dd";
            // 
            // monthLabel
            // 
            this.monthLabel.AutoSize = true;
            this.monthLabel.Location = new System.Drawing.Point(73, 19);
            this.monthLabel.Name = "monthLabel";
            this.monthLabel.Size = new System.Drawing.Size(23, 13);
            this.monthLabel.TabIndex = 4;
            this.monthLabel.Text = "mm";
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.Location = new System.Drawing.Point(140, 18);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(17, 13);
            this.yearLabel.TabIndex = 5;
            this.yearLabel.Text = "yy";
            // 
            // MyDateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.yearLabel);
            this.Controls.Add(this.monthLabel);
            this.Controls.Add(this.dayLabel);
            this.Controls.Add(this.Year);
            this.Controls.Add(this.Month);
            this.Controls.Add(this.Day);
            this.Name = "MyDateControl";
            this.Size = new System.Drawing.Size(201, 49);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Day;
        private System.Windows.Forms.TextBox Month;
        private System.Windows.Forms.TextBox Year;
        private System.Windows.Forms.Label dayLabel;
        private System.Windows.Forms.Label monthLabel;
        private System.Windows.Forms.Label yearLabel;
    }
}
