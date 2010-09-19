using Core.Factory;
using TestSampleApplication.Entities;

namespace TestSampleApplication.WhiteScreens
{
    public partial class SearchCustomerScreen
    {
        public virtual void Search(CustomerSearchCriteria searchCriteria)
        {
            nameTextBox.Text = searchCriteria.Name;
            ageTextBox.Text = searchCriteria.Age;
            search.Click();
        }

        public virtual SearchMoviesScreen LaunchSearchMovies()
        {
            searchMovies.Click();
            return screenRepository.Get<SearchMoviesScreen>("Search Movies", InitializeOption.NoCache);
        }
    }
}