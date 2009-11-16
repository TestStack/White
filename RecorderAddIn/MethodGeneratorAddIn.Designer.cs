namespace RecorderAddIn
{
    partial class MethodGeneratorAddIn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private const string START_RECORDING = "Start &Recording";
        private const string STOP_RECORDING = "Stop &Recording";

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
            this.windowBrowser = new Recorder.View.WindowBrowser();
            this.recordOptionsView = new Recorder.View.RecordOptionsView();
            this.record = new System.Windows.Forms.Button();
            this.codePreviewEditor = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // windowBrowser
            // 
            this.windowBrowser.Location = new System.Drawing.Point(1, 0);
            this.windowBrowser.Name = "windowBrowser";
            this.windowBrowser.Size = new System.Drawing.Size(263, 412);
            this.windowBrowser.TabIndex = 11;
            // 
            // recordOptionsView
            // 
            this.recordOptionsView.Location = new System.Drawing.Point(270, 314);
            this.recordOptionsView.Name = "recordOptionsView";
            this.recordOptionsView.Size = new System.Drawing.Size(222, 98);
            this.recordOptionsView.TabIndex = 13;
            // 
            // record
            // 
            this.record.Location = new System.Drawing.Point(498, 379);
            this.record.Name = "record";
            this.record.Size = new System.Drawing.Size(104, 26);
            this.record.TabIndex = 14;
            this.record.Text = START_RECORDING;
            this.record.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.codePreviewEditor.Location = new System.Drawing.Point(270, 30);
            this.codePreviewEditor.Name = "codePreviewEditor";
            this.codePreviewEditor.Size = new System.Drawing.Size(332, 278);
            this.codePreviewEditor.TabIndex = 15;
            this.codePreviewEditor.Text = "";
            this.codePreviewEditor.ReadOnly = true;
            // 
            // MethodGeneratorAddIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 412);
            this.Controls.Add(this.codePreviewEditor);
            this.Controls.Add(this.record);
            this.Controls.Add(this.recordOptionsView);
            this.Controls.Add(this.windowBrowser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MethodGeneratorAddIn";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "White";
            this.ResumeLayout(false);
        }

        #endregion

        private Recorder.View.WindowBrowser windowBrowser;
        private Recorder.View.RecordOptionsView recordOptionsView;
        private System.Windows.Forms.Button record;
        private System.Windows.Forms.RichTextBox codePreviewEditor;
    }
}