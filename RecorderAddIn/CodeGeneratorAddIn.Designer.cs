namespace RecorderAddIn
{
    partial class CodeGeneratorAddIn
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
            this.windowBrowser = new Recorder.View.WindowBrowser();
            this.generate = new Lunar.Client.View.CommonControls.BricksButton();
            this.screenObjectGeneratorOptionsView = new Recorder.View.ScreenObjectGeneratorOptionsView();
            this.SuspendLayout();
            // 
            // windowBrowser
            // 
            this.windowBrowser.Location = new System.Drawing.Point(1, 0);
            this.windowBrowser.Name = "windowBrowser";
            this.windowBrowser.Size = new System.Drawing.Size(263, 412);
            this.windowBrowser.TabIndex = 11;
            // 
            // generate
            // 
            this.generate.Location = new System.Drawing.Point(397, 148);
            this.generate.Name = "generate";
            this.generate.Size = new System.Drawing.Size(85, 23);
            this.generate.TabIndex = 12;
            this.generate.Text = "&Generate";
            this.generate.UseVisualStyleBackColor = true;
            // 
            // screenObjectGeneratorOptionsView
            // 
            this.screenObjectGeneratorOptionsView.Location = new System.Drawing.Point(270, 12);
            this.screenObjectGeneratorOptionsView.Name = "screenObjectGeneratorOptionsView";
            this.screenObjectGeneratorOptionsView.Size = new System.Drawing.Size(263, 104);
            this.screenObjectGeneratorOptionsView.TabIndex = 13;
            // 
            // CodeGeneratorAddIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 410);
            this.Controls.Add(this.screenObjectGeneratorOptionsView);
            this.Controls.Add(this.generate);
            this.Controls.Add(this.windowBrowser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CodeGeneratorAddIn";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "White";
            this.ResumeLayout(false);

        }

        #endregion

        private Recorder.View.WindowBrowser windowBrowser;
        private Lunar.Client.View.CommonControls.BricksButton generate;
        private Recorder.View.ScreenObjectGeneratorOptionsView screenObjectGeneratorOptionsView;
    }
}