namespace Recorder.View
{
    partial class RecordOptionsView
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
            this.core = new System.Windows.Forms.RadioButton();
            this.screenRepository = new System.Windows.Forms.RadioButton();
            this.recordOptions = new System.Windows.Forms.GroupBox();
            this.bulkText = new System.Windows.Forms.CheckBox();
            this.recordOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // core
            // 
            this.core.AutoSize = true;
            this.core.Location = new System.Drawing.Point(6, 29);
            this.core.Name = "core";
            this.core.Size = new System.Drawing.Size(47, 17);
            this.core.TabIndex = 0;
            this.core.TabStop = true;
            this.core.Text = "Core";
            this.core.UseVisualStyleBackColor = true;
            // 
            // screenRepository
            // 
            this.screenRepository.AutoSize = true;
            this.screenRepository.Location = new System.Drawing.Point(70, 29);
            this.screenRepository.Name = "screenRepository";
            this.screenRepository.Size = new System.Drawing.Size(112, 17);
            this.screenRepository.TabIndex = 1;
            this.screenRepository.TabStop = true;
            this.screenRepository.Text = "Screen Repository";
            this.screenRepository.UseVisualStyleBackColor = true;
            // 
            // recordOptions
            // 
            this.recordOptions.Controls.Add(this.bulkText);
            this.recordOptions.Controls.Add(this.core);
            this.recordOptions.Controls.Add(this.screenRepository);
            this.recordOptions.Location = new System.Drawing.Point(3, 3);
            this.recordOptions.Name = "recordOptions";
            this.recordOptions.Size = new System.Drawing.Size(210, 90);
            this.recordOptions.TabIndex = 2;
            this.recordOptions.TabStop = false;
            this.recordOptions.Text = "Record Options";
            // 
            // bulkText
            // 
            this.bulkText.AutoSize = true;
            this.bulkText.Location = new System.Drawing.Point(7, 55);
            this.bulkText.Name = "bulkText";
            this.bulkText.Size = new System.Drawing.Size(71, 17);
            this.bulkText.TabIndex = 2;
            this.bulkText.Text = "Bulk Text";
            this.bulkText.UseVisualStyleBackColor = true;
            // 
            // RecordOptionsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.recordOptions);
            this.Name = "RecordOptionsView";
            this.Size = new System.Drawing.Size(222, 99);
            this.recordOptions.ResumeLayout(false);
            this.recordOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton core;
        private System.Windows.Forms.RadioButton screenRepository;
        private System.Windows.Forms.GroupBox recordOptions;
        private System.Windows.Forms.CheckBox bulkText;

    }
}
