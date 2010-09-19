using Core;
using Core.UIItems;
using Core.UIItems.WindowItems;
using TestSampleApplication.Entities;

namespace TestSampleApplication.Screens
{
    public class CreateCustomerStep2Screen
    {
        private readonly Window window;
        private Application application;

        public CreateCustomerStep2Screen(Window window, Application application)
        {
            this.window = window;
            this.application = application;
        }

        public void Fill(Customer customer)
        {
            window.Get<TextBox>("phoneNumberTextBox").BulkText = customer.PhoneNumber;
            window.Get<Button>("submitButton").Click();
        }

        public void Fill(string phoneNumber)
        {
            window.Get<TextBox>("phoneNumberTextBox").BulkText = phoneNumber;
            window.Get<Button>("submitButton").Click();
        }
    }
}