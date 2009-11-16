using System.Collections.Generic;
using NUnit.Framework;
using TestSampleApplication.Entities;
using TestSampleApplication.Screens;

namespace TestSampleApplication.Tests
{
    [TestFixture]
    public class SearchCustomerTestUsingEntities : VideoLibraryTest
    {
        [Test]
        public void Search()
        {
            DashboardScreen dashboardScreen = new DashboardScreen(window, application);
            SearchCustomerScreen searchCustomerScreen = dashboardScreen.LaunchSearchCustomer();
            CustomerSearchCriteria customerSearchCriteria = new CustomerSearchCriteria("Suman", "");
            List<Customer> customers = searchCustomerScreen.Search(customerSearchCriteria);
            Assert.AreEqual(1, customers.Count);
        }

        [Test]
        public void Search_ExpressingEntityInAnotherWay()
        {
            DashboardScreen dashboardScreen = new DashboardScreen(window, application);
            SearchCustomerScreen searchCustomerScreen = dashboardScreen.LaunchSearchCustomer();
            CustomerSearchCriteria searchCriteria = new CustomerSearchCriteria().OfName("Suman").OfAge("20");
            List<Customer> customers = searchCustomerScreen.Search(searchCriteria);
            Assert.AreEqual(1, customers.Count);
        }
    }
}