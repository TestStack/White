using Core.Factory;
using NUnit.Framework;
using Repository;
using TestSampleApplication.Entities;
using TestSampleApplication.Services;
using TestSampleApplication.WhiteScreens;

namespace TestSampleApplication.Tests.Services
{
    [TestFixture]
    public class IssueMovieTest_UsingServices : VideoLibraryTest
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
            new CustomerService(dashboard).CreateCustomer(customer);
            new MovieService(dashboard).IssueMovie(new CustomerSearchCriteria("Rahul", string.Empty), new MovieSearchCriteria("Sholay", string.Empty));
        }

        [Test]
        public void IssueAdultMovieToMinor()
        {
            Customer customer = new Customer("Yusuf", "10", "33343433");
            new CustomerService(dashboard).CreateCustomer(customer);
            new MovieService(dashboard).IssueMovie(new CustomerSearchCriteria("Yusuf", string.Empty), new MovieSearchCriteria("Sholay", string.Empty));
            //Verify errors etc
        }
    }
}