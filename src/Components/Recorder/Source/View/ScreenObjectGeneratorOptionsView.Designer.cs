namespace Recorder.View
{
    partial class ScreenObjectGeneratorOptionsView
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
            this.ignoreLabels = new System.Windows.Forms.CheckBox();
            this.namespaceLabel = new System.Windows.Forms.Label();
            this.namespaceText = new System.Windows.Forms.TextBox();
            this.generateOptions = new System.Windows.Forms.GroupBox();
            this.generateOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // ignoreLabels
            // 
            this.ignoreLabels.AutoSize = true;
            this.ignoreLabels.Location = new System.Drawing.Point(6, 23);
            this.ignoreLabels.Name = "ignoreLabels";
            this.ignoreLabels.Size = new System.Drawing.Size(90, 17);
            this.ignoreLabels.TabIndex = 10;
            this.ignoreLabels.Text = "Ignore &Labels";
            this.ignoreLabels.UseVisualStyleBackColor = true;
            // 
            // namespaceLabel
            // 
            this.namespaceLabel.AutoSize = true;
            this.namespaceLabel.Location = new System.Drawing.Point(3, 49);
            this.namespaceLabel.Name = "namespaceLabel";
            this.namespaceLabel.Size = new System.Drawing.Size(67, 13);
            this.namespaceLabel.TabIndex = 11;
            this.namespaceLabel.Text = "Namespace:";
            // 
            // namespaceText
            // 
            this.namespaceText.Location = new System.Drawing.Point(76, 46);
            this.namespaceText.Name = "namespaceText";
            this.namespaceText.Size = new System.Drawing.Size(131, 20);
            this.namespaceText.TabIndex = 12;
            // 
            // generateOptions
            // 
            this.generateOptions.Controls.Add(this.ignoreLabels);
            this.generateOptions.Controls.Add(this.namespaceText);
            this.generateOptions.Controls.Add(this.namespaceLabel);
            this.generateOptions.Location = new System.Drawing.Point(3, 3);
            this.generateOptions.Name = "generateOptions";
            this.generateOptions.Size = new System.Drawing.Size(255, 107);
            this.generateOptions.TabIndex = 13;
            this.generateOptions.TabStop = false;
            this.generateOptions.Text = "Generate Options";
            // 
            // ScreenObjectGeneratorOptionsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.generateOptions);
            this.Name = "ScreenObjectGeneratorOptionsView";
            this.Size = new System.Drawing.Size(268, 116);
            this.generateOptions.ResumeLayout(false);
            this.generateOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox ignoreLabels;
        private System.Windows.Forms.Label namespaceLabel;
        private System.Windows.Forms.TextBox namespaceText;
        private System.Windows.Forms.GroupBox generateOptions;
    }
}
