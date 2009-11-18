namespace SampleApplication
{
    partial class SearchMovies
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextbox = new System.Windows.Forms.TextBox();
            this.directorTextbox = new System.Windows.Forms.TextBox();
            this.directorLabel = new System.Windows.Forms.Label();
            this.search = new System.Windows.Forms.Button();
            this.foundMovies = new System.Windows.Forms.DataGridView();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.select = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.foundMovies)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(13, 22);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name";
            // 
            // nameTextbox
            // 
            this.nameTextbox.Location = new System.Drawing.Point(63, 19);
            this.nameTextbox.Name = "nameTextbox";
            this.nameTextbox.Size = new System.Drawing.Size(129, 20);
            this.nameTextbox.TabIndex = 1;
            // 
            // directorTextbox
            // 
            this.directorTextbox.Location = new System.Drawing.Point(63, 57);
            this.directorTextbox.Name = "directorTextbox";
            this.directorTextbox.Size = new System.Drawing.Size(129, 20);
            this.directorTextbox.TabIndex = 3;
            // 
            // directorLabel
            // 
            this.directorLabel.AutoSize = true;
            this.directorLabel.Location = new System.Drawing.Point(13, 60);
            this.directorLabel.Name = "directorLabel";
            this.directorLabel.Size = new System.Drawing.Size(44, 13);
            this.directorLabel.TabIndex = 2;
            this.directorLabel.Text = "Director";
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(116, 84);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(75, 23);
            this.search.TabIndex = 4;
            this.search.Text = "Sea&rch";
            this.search.UseVisualStyleBackColor = true;
            // 
            // foundMovies
            // 
            this.foundMovies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.foundMovies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameColumn,
            this.ageColumn,
            this.phoneNumberColumn});
            this.foundMovies.Location = new System.Drawing.Point(16, 123);
            this.foundMovies.Name = "foundMovies";
            this.foundMovies.Size = new System.Drawing.Size(472, 150);
            this.foundMovies.TabIndex = 6;
            // 
            // nameColumn
            // 
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.Name = "nameColumn";
            // 
            // ageColumn
            // 
            this.ageColumn.HeaderText = "Director";
            this.ageColumn.Name = "ageColumn";
            // 
            // phoneNumberColumn
            // 
            this.phoneNumberColumn.HeaderText = "For Minors";
            this.phoneNumberColumn.Name = "phoneNumberColumn";
            // 
            // select
            // 
            this.select.Location = new System.Drawing.Point(412, 290);
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(75, 23);
            this.select.TabIndex = 7;
            this.select.Text = "&Select";
            this.select.UseVisualStyleBackColor = true;
            // 
            // SearchMovies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 322);
            this.Controls.Add(this.select);
            this.Controls.Add(this.foundMovies);
            this.Controls.Add(this.search);
            this.Controls.Add(this.directorTextbox);
            this.Controls.Add(this.directorLabel);
            this.Controls.Add(this.nameTextbox);
            this.Controls.Add(this.nameLabel);
            this.Name = "SearchMovies";
            this.Text = "Search Movies";
            ((System.ComponentModel.ISupportInitialize)(this.foundMovies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextbox;
        private System.Windows.Forms.TextBox directorTextbox;
        private System.Windows.Forms.Label directorLabel;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.DataGridView foundMovies;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneNumberColumn;
        private System.Windows.Forms.Button select;
    }
}