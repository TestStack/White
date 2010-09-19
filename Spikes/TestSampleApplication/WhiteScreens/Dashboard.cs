using Core.Factory;

namespace TestSampleApplication.WhiteScreens
{
    public partial class Dashboard
    {
        public virtual CreateCustomerStep1Screen LaunchCreateCustomer()
        {
            createCustomer.Click();
            return screenRepository.Get<CreateCustomerStep1Screen>("Create Customer Step1", InitializeOption.NoCache);
        }

        public virtual SearchCustomerScreen LaunchSearchCustomer()
        {
            searchCustomer.Click();
            return screenRepository.Get<SearchCustomerScreen>("Search Customer", InitializeOption.NoCache);
        }
    }
}