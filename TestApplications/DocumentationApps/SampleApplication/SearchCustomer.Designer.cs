namespace SampleApplication
{
    partial class SearchCustomer
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
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.ageTextBox = new System.Windows.Forms.TextBox();
            this.ageLabel = new System.Windows.Forms.Label();
            this.search = new System.Windows.Forms.Button();
            this.foundCustomers = new System.Windows.Forms.DataGridView();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteButton = new System.Windows.Forms.Button();
            this.searchMovies = new System.Windows.Forms.LinkLabel();
            this.selectedMovie = new System.Windows.Forms.Label();
            this.selectedMovieLabel = new System.Windows.Forms.Label();
            this.ok = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.foundCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(13, 28);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(55, 28);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // ageTextBox
            // 
            this.ageTextBox.Location = new System.Drawing.Point(55, 66);
            this.ageTextBox.Name = "ageTextBox";
            this.ageTextBox.Size = new System.Drawing.Size(100, 20);
            this.ageTextBox.TabIndex = 3;
            // 
            // ageLabel
            // 
            this.ageLabel.AutoSize = true;
            this.ageLabel.Location = new System.Drawing.Point(13, 69);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(26, 13);
            this.ageLabel.TabIndex = 2;
            this.ageLabel.Text = "Age";
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(206, 26);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(75, 23);
            this.search.TabIndex = 4;
            this.search.Text = "&Search";
            this.search.UseVisualStyleBackColor = true;
            // 
            // foundCustomers
            // 
            this.foundCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.foundCustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameColumn,
            this.ageColumn,
            this.phoneNumberColumn});
            this.foundCustomers.Location = new System.Drawing.Point(16, 130);
            this.foundCustomers.Name = "foundCustomers";
            this.foundCustomers.Size = new System.Drawing.Size(472, 150);
            this.foundCustomers.TabIndex = 5;
            // 
            // nameColumn
            // 
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.Name = "nameColumn";
            // 
            // ageColumn
            // 
            this.ageColumn.HeaderText = "Age";
            this.ageColumn.Name = "ageColumn";
            // 
            // phoneNumberColumn
            // 
            this.phoneNumberColumn.HeaderText = "PhoneNumber";
            this.phoneNumberColumn.Name = "phoneNumberColumn";
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(413, 286);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 6;
            this.deleteButton.Text = "&Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // searchMovies
            // 
            this.searchMovies.AutoSize = true;
            this.searchMovies.Location = new System.Drawing.Point(13, 376);
            this.searchMovies.Name = "searchMovies";
            this.searchMovies.Size = new System.Drawing.Size(78, 13);
            this.searchMovies.TabIndex = 7;
            this.searchMovies.TabStop = true;
            this.searchMovies.Text = "Search Movies";
            // 
            // selectedMovie
            // 
            this.selectedMovie.AutoSize = true;
            this.selectedMovie.Location = new System.Drawing.Point(82, 405);
            this.selectedMovie.Name = "selectedMovie";
            this.selectedMovie.Size = new System.Drawing.Size(0, 13);
            this.selectedMovie.TabIndex = 8;
            // 
            // selectedMovieLabel
            // 
            this.selectedMovieLabel.AutoSize = true;
            this.selectedMovieLabel.Location = new System.Drawing.Point(13, 405);
            this.selectedMovieLabel.Name = "selectedMovieLabel";
            this.selectedMovieLabel.Size = new System.Drawing.Size(49, 13);
            this.selectedMovieLabel.TabIndex = 9;
            this.selectedMovieLabel.Text = "Selected";
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(412, 478);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 10;
            this.ok.Text = "&OK";
            this.ok.UseVisualStyleBackColor = true;
            // 
            // SearchCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 513);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.selectedMovieLabel);
            this.Controls.Add(this.selectedMovie);
            this.Controls.Add(this.searchMovies);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.foundCustomers);
            this.Controls.Add(this.search);
            this.Controls.Add(this.ageTextBox);
            this.Controls.Add(this.ageLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.nameLabel);
            this.Name = "SearchCustomer";
            this.Text = "Search Customer";
            ((System.ComponentModel.ISupportInitialize)(this.foundCustomers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox ageTextBox;
        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.DataGridView foundCustomers;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneNumberColumn;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.LinkLabel searchMovies;
        private System.Windows.Forms.Label selectedMovie;
        private System.Windows.Forms.Label selectedMovieLabel;
        private System.Windows.Forms.Button ok;

    }
}