using Lunar.Client.View.CommonControls;

namespace Recorder
{
    partial class DashBoard
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
            this.codeEditor = new System.Windows.Forms.RichTextBox();
            this.generateWindowClass = new Lunar.Client.View.CommonControls.BricksButton();
            this.status = new System.Windows.Forms.StatusStrip();
            this.record = new System.Windows.Forms.Button();
            this.recordOptionsView = new Recorder.View.RecordOptionsView();
            this.windowBrowser = new Recorder.View.WindowBrowser();
            this.screenObjectGeneratorOptionsView = new Recorder.View.ScreenObjectGeneratorOptionsView();
            this.SuspendLayout();
            // 
            // codeEditor
            // 
            this.codeEditor.Location = new System.Drawing.Point(326, 12);
            this.codeEditor.Name = "codeEditor";
            this.codeEditor.Size = new System.Drawing.Size(547, 606);
            this.codeEditor.TabIndex = 1;
            this.codeEditor.Text = "";
            // 
            // generateWindowClass
            // 
            this.generateWindowClass.Location = new System.Drawing.Point(218, 203);
            this.generateWindowClass.Name = "generateWindowClass";
            this.generateWindowClass.Size = new System.Drawing.Size(99, 23);
            this.generateWindowClass.TabIndex = 4;
            this.generateWindowClass.Text = "&Generate Class";
            this.generateWindowClass.UseVisualStyleBackColor = true;
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(0, 637);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(1141, 22);
            this.status.TabIndex = 5;
            this.status.Text = "statusStrip1";
            // 
            // record
            // 
            this.record.Location = new System.Drawing.Point(218, 232);
            this.record.Name = "record";
            this.record.Size = new System.Drawing.Size(99, 23);
            this.record.TabIndex = 8;
            this.record.Text = "&Record";
            this.record.UseVisualStyleBackColor = true;
            // 
            // recordOptionsView
            // 
            this.recordOptionsView.Location = new System.Drawing.Point(880, 132);
            this.recordOptionsView.Name = "recordOptionsView";
            this.recordOptionsView.Size = new System.Drawing.Size(222, 98);
            this.recordOptionsView.TabIndex = 11;
            // 
            // windowBrowser
            // 
            this.windowBrowser.Location = new System.Drawing.Point(0, 2);
            this.windowBrowser.Name = "windowBrowser";
            this.windowBrowser.Size = new System.Drawing.Size(212, 616);
            this.windowBrowser.TabIndex = 10;
            // 
            // screenObjectGeneratorOptionsView
            // 
            this.screenObjectGeneratorOptionsView.Location = new System.Drawing.Point(879, 12);
            this.screenObjectGeneratorOptionsView.Name = "screenObjectGeneratorOptionsView";
            this.screenObjectGeneratorOptionsView.Size = new System.Drawing.Size(263, 114);
            this.screenObjectGeneratorOptionsView.TabIndex = 9;
            // 
            // DashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 659);
            this.Controls.Add(this.recordOptionsView);
            this.Controls.Add(this.windowBrowser);
            this.Controls.Add(this.screenObjectGeneratorOptionsView);
            this.Controls.Add(this.record);
            this.Controls.Add(this.status);
            this.Controls.Add(this.generateWindowClass);
            this.Controls.Add(this.codeEditor);
            this.Name = "DashBoard";
            this.Text = "DashBoard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox codeEditor;
        private BricksButton generateWindowClass;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.Button record;
        private Recorder.View.ScreenObjectGeneratorOptionsView screenObjectGeneratorOptionsView;
        private Recorder.View.WindowBrowser windowBrowser;
        private Recorder.View.RecordOptionsView recordOptionsView;
    }
}