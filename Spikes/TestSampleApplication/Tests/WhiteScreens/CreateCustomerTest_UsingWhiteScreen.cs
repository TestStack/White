using Core;
using Core.Factory;
using NUnit.Framework;
using Repository;
using TestSampleApplication.Entities;
using TestSampleApplication.WhiteScreens;

namespace TestSampleApplication.Tests.WhiteScreens
{
    [TestFixture]
    public class CreateCustomerTest_UsingWhiteScreen
    {
        private Application application;

        [SetUp]
        public void SetUp()
        {
            application = Application.Launch(@"..\..\..\SampleApplication\bin\debug\SampleApplication.exe");            
        }

        [Test]
        public void Create()
        {
            ScreenRepository screenRepository = new ScreenRepository(application.ApplicationSession);
            Dashboard dashboard = screenRepository.Get<Dashboard>("Dashboard", InitializeOption.NoCache);
            CreateCustomerStep1Screen customerStep1Screen = dashboard.LaunchCreateCustomer();

            Customer customer = new Customer("Rahul", "20", "4366654");
            CreateCustomerStep2Screen customerStep2Screen = customerStep1Screen.FillAndNext(customer);
            customerStep2Screen.Finish(customer);
        }

        [Test]
        public void Create_PopulatingAutomatically()
        {
            ScreenRepository screenRepository = new ScreenRepository(application.ApplicationSession);
            Dashboard dashboard = screenRepository.Get<Dashboard>("Dashboard", InitializeOption.NoCache);
            CreateCustomerStep1Screen customerStep1Screen = dashboard.LaunchCreateCustomer();

            Customer customer = new Customer("Rahul", "20", "4366654");
            CreateCustomerStep2Screen customerStep2Screen = customerStep1Screen.FillAndNext_UsingAutomaticPopulate(customer);
            customerStep2Screen.Finish_UsingAutomaticPopulate(customer);
        }

        [TearDown]
        public void TearDown()
        {
            application.Kill();            
        }
    }
}