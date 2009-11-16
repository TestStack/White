using TestSampleApplication.Entities;
using TestSampleApplication.WhiteScreens;

namespace TestSampleApplication.Services
{
    public class MovieService
    {
        private readonly Dashboard dashboard;

        public MovieService(Dashboard dashboard)
        {
            this.dashboard = dashboard;
        }

        public virtual void IssueMovie(CustomerSearchCriteria customerSearchCriteria, MovieSearchCriteria movieSearchCriteria)
        {
            SearchCustomerScreen searchCustomerScreen = dashboard.LaunchSearchCustomer();
            searchCustomerScreen.Search(customerSearchCriteria);
            SearchMoviesScreen searchMoviesScreen = searchCustomerScreen.LaunchSearchMovies();
            searchMoviesScreen.Search(movieSearchCriteria);
            searchMoviesScreen.Select();
        }
    }
}