using TestSampleApplication.Entities;
using TestSampleApplication.WhiteScreens;

namespace TestSampleApplication.Services
{
    public class CustomerService
    {
        private readonly Dashboard dashboard;

        public CustomerService(Dashboard dashboard) {
            this.dashboard = dashboard;
        }

        public virtual void CreateCustomer(Customer customer)
        {
            CreateCustomerStep1Screen customerStep1Screen = dashboard.LaunchCreateCustomer();
            CreateCustomerStep2Screen customerStep2Screen = customerStep1Screen.FillAndNext(customer);
            customerStep2Screen.Finish(customer);
        }
    }
}