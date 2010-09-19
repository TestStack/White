using NUnit.Framework;
using TestSampleApplication.Screens;

namespace TestSampleApplication.Tests
{
    [TestFixture]
    public class SearchCustomerTestUsingScreenObjectPattern : VideoLibraryTest
    {
        [Test]
        public void SearchByName()
        {
            DashboardScreen dashboardScreen = new DashboardScreen(window, application);
            SearchCustomerScreen searchCustomerScreen = dashboardScreen.LaunchSearchCustomer();
            int numberOfCustomers = searchCustomerScreen.Search("Suman", "");
            Assert.AreEqual(1, numberOfCustomers);
        }

        [Test]
        public void SearchByAge()
        {
            DashboardScreen dashboardScreen = new DashboardScreen(window, application);
            SearchCustomerScreen searchCustomerScreen = dashboardScreen.LaunchSearchCustomer();
            int numberOfCustomers = searchCustomerScreen.Search("", "20");
            Assert.AreEqual(1, numberOfCustomers);
        }
    }
}