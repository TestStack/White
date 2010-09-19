using NUnit.Framework;
using TestSampleApplication.Entities;
using TestSampleApplication.Screens;

namespace TestSampleApplication.Tests
{
    [TestFixture]
    public class CreateCustomerTestUsingScreenObjectPattern : VideoLibraryTest
    {
        [Test]
        public void Create()
        {
            DashboardScreen dashboardScreen = new DashboardScreen(window, application);
            Customer customer = new Customer("Rakesh Kumar", "26", "34343545");
            CreateCustomerStep1Screen step1Screen = dashboardScreen.LaunchCreateCustomer();
            step1Screen.FillAndNext(customer);
            CreateCustomerStep2Screen step2Screen = new CreateCustomerStep2Screen(window, application);
            step2Screen.Fill(customer);
        }

        [Test]
        public void CreateCustomerWithoutEntities()
        {
            DashboardScreen dashboardScreen = new DashboardScreen(window, application);
            CreateCustomerStep1Screen step1Screen = dashboardScreen.LaunchCreateCustomer();
            step1Screen.FillAndNext("Rakesh Kumar", "26");
            CreateCustomerStep2Screen step2Screen = new CreateCustomerStep2Screen(window, application);
            step2Screen.Fill("34343545");
        }
    }
}