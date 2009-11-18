using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SampleApplication.Domain;

namespace SampleApplication
{
    public partial class SearchMovies : Form
    {
        public SearchMovies()
        {
            InitializeComponent();
            foundMovies.ReadOnly = true;
            foundMovies.AllowUserToAddRows = false;

            search.Click += Search_OnClick;
            select.Click += Select_OnClick;
        }

        private void Select_OnClick(object sender, EventArgs e)
        {
            Movie movie = (Movie) foundMovies.CurrentRow.Tag;
            ApplicationContext.SelectedMovie = movie;
            Close();
        }

        private void Search_OnClick(object sender, EventArgs e)
        {
            string nameCriteria = nameTextbox.Text;
            string directorCriteria = directorTextbox.Text;
            List<Movie> movies = DataStore.Movies.FindAll(delegate(Movie obj)
                                                                  {
                                                                      return !string.IsNullOrEmpty(directorCriteria) && obj.Director.Contains(directorCriteria) ||
                                                                             (!string.IsNullOrEmpty(nameCriteria) && obj.Name.Contains(nameCriteria));
                                                                  });
            DisplayMovies(movies);
        }


        private void DisplayMovies(List<Movie> movies)
        {
            foundMovies.Rows.Clear();
            movies.ForEach(delegate(Movie obj)
                                  {
                                      foundMovies.Rows.Add(obj.Name, obj.Director, obj.ForMinors ? "Yes" : "No");
                                      foundMovies.Rows[foundMovies.Rows.Count - 1].Tag = obj;
                                  });
        }
    }
}