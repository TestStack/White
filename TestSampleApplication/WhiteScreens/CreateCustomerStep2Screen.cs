using TestSampleApplication.Entities;
using TestSampleApplication.Util;

namespace TestSampleApplication.WhiteScreens
{
    public partial class CreateCustomerStep2Screen
    {
        public virtual void Finish(Customer customer)
        {
            phoneNumberTextBox.Text = customer.PhoneNumber;
            submitButton.Click();
        }

        public virtual void Finish_UsingAutomaticPopulate(Customer customer)
        {
            Populate(new VideoLibraryFieldMap(), customer);
            submitButton.Click();
        }
    }
}