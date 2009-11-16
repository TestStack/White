using Core.Factory;
using TestSampleApplication.Entities;
using TestSampleApplication.Util;

namespace TestSampleApplication.WhiteScreens
{
    public partial class CreateCustomerStep1Screen
    {
        public virtual CreateCustomerStep2Screen FillAndNext(Customer customer)
        {
            nameTextBox.BulkText = customer.Name;
            ageTextBox.BulkText = customer.Age;
            nextButton.Click();
            return screenRepository.Get<CreateCustomerStep2Screen>("Create Customer Step2", InitializeOption.NoCache);
        }

        public virtual CreateCustomerStep2Screen FillAndNext_UsingAutomaticPopulate(Customer customer)
        {
            Populate(new VideoLibraryFieldMap(), customer);
            nextButton.Click();
            return screenRepository.Get<CreateCustomerStep2Screen>("Create Customer Step2", InitializeOption.NoCache);
        }
    }
}