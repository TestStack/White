using TestSampleApplication.Entities;

namespace TestSampleApplication.WhiteScreens
{
    public partial class SearchMoviesScreen
    {
        public virtual void Search(MovieSearchCriteria criteria)
        {
            nameTextbox.Text = criteria.Name;
            directorTextbox.Text = criteria.Director;
            search.Click();
        }

        public virtual void Select()
        {
            select.Click();
        }
    }
}