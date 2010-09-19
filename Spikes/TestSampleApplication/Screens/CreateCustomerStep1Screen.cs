using Core;
using Core.Factory;
using Core.UIItems;
using Core.UIItems.WindowItems;
using TestSampleApplication.Entities;

namespace TestSampleApplication.Screens
{
    public class CreateCustomerStep1Screen
    {
        private readonly Window window;
        private readonly Application application;

        public CreateCustomerStep1Screen(Window window, Application application)
        {
            this.window = window;
            this.application = application;
        }

        public CreateCustomerStep2Screen FillAndNext(Customer customer)
        {
            window.Get<TextBox>("nameTextBox").BulkText = customer.Name;
            window.Get<TextBox>("ageTextBox").BulkText = customer.Age;
            window.Get<Button>("nextButton").Click();
            Window step2 = application.GetWindow("Create Customer Step2", InitializeOption.NoCache);
            return new CreateCustomerStep2Screen(step2, application);
        }

        public CreateCustomerStep2Screen FillAndNext(string name, string age)
        {
            window.Get<TextBox>("nameTextBox").BulkText = name;
            window.Get<TextBox>("ageTextBox").BulkText = age;
            window.Get<Button>("nextButton").Click();
            Window step2 = application.GetWindow("Create Customer Step2", InitializeOption.NoCache);
            return new CreateCustomerStep2Screen(step2, application);            
        }
    }
}