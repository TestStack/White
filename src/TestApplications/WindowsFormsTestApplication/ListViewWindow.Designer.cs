namespace WindowsFormsTestApplication
{
    partial class ListViewWindow
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Search",
            "Google"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Mail",
            "GMail"}, -1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "Picture",
            "Piccasa"}, -1);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {"Action1","App1"}, -1);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] { "Action2", "App2" }, -1);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem(new string[] { "Action3", "App3" }, -1);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem(new string[] { "Action4", "App4" }, -1);
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem(new string[] { "Action5", "App5" }, -1);
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem(new string[] { "Action6", "App6" }, -1);
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem(new string[] { "Action7", "App7" }, -1);
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem(new string[] { "Action8", "App8" }, -1);
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem(new string[] { "Action9", "App9" }, -1);
            System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem(new string[] { "Action10", "App10" }, -1);
            System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem(new string[] { "Action11", "App11" }, -1);
            System.Windows.Forms.ListViewItem listViewItem15 = new System.Windows.Forms.ListViewItem(new string[] { "Action12", "App12" }, -1);
            System.Windows.Forms.ListViewItem listViewItem16 = new System.Windows.Forms.ListViewItem(new string[] { "Action13", "App13" }, -1);
            System.Windows.Forms.ListViewItem listViewItem17 = new System.Windows.Forms.ListViewItem(new string[] { "Action14", "App14" }, -1);
            System.Windows.Forms.ListViewItem listViewItem18 = new System.Windows.Forms.ListViewItem(new string[] { "Action15", "App15" }, -1);
            System.Windows.Forms.ListViewItem listViewItem20 = new System.Windows.Forms.ListViewItem("bar");
            System.Windows.Forms.ListViewItem listViewItem21 = new System.Windows.Forms.ListViewItem("bardfgreerrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrre");
            this.ListView = new System.Windows.Forms.ListView();
            this.Key = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ListViewWithHorizontalScroll = new System.Windows.Forms.ListView();
            this.columnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // ListView
            // 
            this.ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Key,
            this.Value});
            this.ListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10,
            listViewItem11,
            listViewItem12,
            listViewItem13,
            listViewItem14,
            listViewItem15,
            listViewItem16,
            listViewItem17,
            listViewItem18});
            this.ListView.Location = new System.Drawing.Point(13, 13);
            this.ListView.Name = "ListView";
            this.ListView.Size = new System.Drawing.Size(308, 302);
            this.ListView.TabIndex = 0;
            this.ListView.UseCompatibleStateImageBehavior = false;
            this.ListView.View = System.Windows.Forms.View.Details;
            this.ListView.SelectedIndexChanged += new System.EventHandler(this.ListView_SelectedIndexChanged);
            // 
            // Key
            // 
            this.Key.Tag = "Key";
            this.Key.Text = "Key";
            // 
            // Value
            // 
            this.Value.Tag = "Value";
            this.Value.Text = "Value";
            // 
            // ListViewWithHorizontalScroll
            // 
            this.ListViewWithHorizontalScroll.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader});
            this.ListViewWithHorizontalScroll.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem20,
            listViewItem21});
            this.ListViewWithHorizontalScroll.Location = new System.Drawing.Point(327, 13);
            this.ListViewWithHorizontalScroll.Name = "ListViewWithHorizontalScroll";
            this.ListViewWithHorizontalScroll.Size = new System.Drawing.Size(109, 302);
            this.ListViewWithHorizontalScroll.TabIndex = 1;
            this.ListViewWithHorizontalScroll.UseCompatibleStateImageBehavior = false;
            this.ListViewWithHorizontalScroll.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader
            // 
            this.columnHeader.Tag = "Key";
            this.columnHeader.Text = "Key";
            this.columnHeader.Width = 262;
            // 
            // ListViewWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 327);
            this.Controls.Add(this.ListViewWithHorizontalScroll);
            this.Controls.Add(this.ListView);
            this.Name = "ListViewWindow";
            this.Text = "ListViewWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ListView;
        private System.Windows.Forms.ColumnHeader Key;
        private System.Windows.Forms.ColumnHeader Value;
        private System.Windows.Forms.ListView ListViewWithHorizontalScroll;
        private System.Windows.Forms.ColumnHeader columnHeader;
    }
}