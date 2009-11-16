namespace Recorder.View
{
    partial class WindowBrowser
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
            this.visibleWindows = new System.Windows.Forms.Label();
            this.desktopApplications = new System.Windows.Forms.Label();
            this.applications = new Lunar.Client.View.CommonControls.BricksListBox();
            this.windows = new System.Windows.Forms.ListBox();
            this.windowTabs = new System.Windows.Forms.ListBox();
            this.tabs = new System.Windows.Forms.Label();
            this.pages = new System.Windows.Forms.Label();
            this.tabPages = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // visibleWindows
            // 
            this.visibleWindows.AutoSize = true;
            this.visibleWindows.Location = new System.Drawing.Point(1, 183);
            this.visibleWindows.Name = "visibleWindows";
            this.visibleWindows.Size = new System.Drawing.Size(84, 13);
            this.visibleWindows.TabIndex = 11;
            this.visibleWindows.Text = "Visible Windows";
            // 
            // desktopApplications
            // 
            this.desktopApplications.AutoSize = true;
            this.desktopApplications.Location = new System.Drawing.Point(4, 7);
            this.desktopApplications.Name = "desktopApplications";
            this.desktopApplications.Size = new System.Drawing.Size(107, 13);
            this.desktopApplications.TabIndex = 10;
            this.desktopApplications.Text = "Desktop Applications";
            // 
            // applications
            // 
            this.applications.FormattingEnabled = true;
            this.applications.Location = new System.Drawing.Point(3, 29);
            this.applications.Name = "applications";
            this.applications.Size = new System.Drawing.Size(203, 147);
            this.applications.TabIndex = 9;
            // 
            // windows
            // 
            this.windows.FormattingEnabled = true;
            this.windows.Location = new System.Drawing.Point(4, 201);
            this.windows.Name = "windows";
            this.windows.Size = new System.Drawing.Size(202, 147);
            this.windows.TabIndex = 8;
            // 
            // windowTabs
            // 
            this.windowTabs.FormattingEnabled = true;
            this.windowTabs.Location = new System.Drawing.Point(3, 374);
            this.windowTabs.Name = "windowTabs";
            this.windowTabs.Size = new System.Drawing.Size(202, 95);
            this.windowTabs.TabIndex = 12;
            // 
            // tabs
            // 
            this.tabs.AutoSize = true;
            this.tabs.Location = new System.Drawing.Point(4, 358);
            this.tabs.Name = "tabs";
            this.tabs.Size = new System.Drawing.Size(31, 13);
            this.tabs.TabIndex = 13;
            this.tabs.Text = "Tabs";
            // 
            // pages
            // 
            this.pages.AutoSize = true;
            this.pages.Location = new System.Drawing.Point(4, 476);
            this.pages.Name = "pages";
            this.pages.Size = new System.Drawing.Size(37, 13);
            this.pages.TabIndex = 14;
            this.pages.Text = "Pages";
            // 
            // tabPages
            // 
            this.tabPages.FormattingEnabled = true;
            this.tabPages.Location = new System.Drawing.Point(3, 492);
            this.tabPages.Name = "tabPages";
            this.tabPages.Size = new System.Drawing.Size(202, 147);
            this.tabPages.TabIndex = 15;
            // 
            // WindowBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabPages);
            this.Controls.Add(this.pages);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.windowTabs);
            this.Controls.Add(this.visibleWindows);
            this.Controls.Add(this.desktopApplications);
            this.Controls.Add(this.applications);
            this.Controls.Add(this.windows);
            this.Name = "WindowBrowser";
            this.Size = new System.Drawing.Size(215, 651);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label visibleWindows;
        private System.Windows.Forms.Label desktopApplications;
        private Lunar.Client.View.CommonControls.BricksListBox applications;
        private System.Windows.Forms.ListBox windows;
        private System.Windows.Forms.ListBox windowTabs;
        private System.Windows.Forms.Label tabs;
        private System.Windows.Forms.Label pages;
        private System.Windows.Forms.ListBox tabPages;
    }
}
