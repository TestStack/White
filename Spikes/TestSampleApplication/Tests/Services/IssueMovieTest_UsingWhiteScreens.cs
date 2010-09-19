using Core.Factory;
using NUnit.Framework;
using Repository;
using TestSampleApplication.Entities;
using TestSampleApplication.WhiteScreens;

namespace TestSampleApplication.Tests.Services
{
    [TestFixture]
    public class IssueMovieTest_UsingWhiteScreens : VideoLibraryTest
    {
        private Dashboard dashboard;
        private ScreenRepository screenRepository;

        protected override void TestSpecificSetup()
        {
            screenRepository = new ScreenRepository(application.ApplicationSession);
            dashboard = screenRepository.Get<Dashboard>("Dashboard", InitializeOption.NoCache);
        }

        [Test]
        public void IssueAdultMovieToNonMinor()
        {
            Customer customer = new Customer("Rahul", "30", "33343433");
            CreateCustomer(customer);
            IssueMovie(new CustomerSearchCriteria("Rahul", string.Empty));
        }

        [Test]
        public void IssueAdultMovieToMinor()
        {
            Customer customer = new Customer("Yusuf", "10", "33343433");
            CreateCustomer(customer);
            IssueMovie(new CustomerSearchCriteria("Yusuf", string.Empty));
            //Verify errors etc
        }

        private void CreateCustomer(Customer customer)
        {
            CreateCustomerStep1Screen customerStep1Screen = dashboard.LaunchCreateCustomer();
            CreateCustomerStep2Screen customerStep2Screen = customerStep1Screen.FillAndNext(customer);
            customerStep2Screen.Finish(customer);
        }

        private void IssueMovie(CustomerSearchCriteria customerSearchCriteria)
        {
            SearchCustomerScreen searchCustomerScreen = dashboard.LaunchSearchCustomer();
            searchCustomerScreen.Search(customerSearchCriteria);
            SearchMoviesScreen searchMoviesScreen = searchCustomerScreen.LaunchSearchMovies();
            searchMoviesScreen.Search(new MovieSearchCriteria("Sholay", string.Empty));
            searchMoviesScreen.Select();
        }
    }
}