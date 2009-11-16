using Core;
using Core.Factory;
using Core.UIItems;
using Core.UIItems.WindowItems;
using NUnit.Framework;

namespace TestSampleApplication.Tests
{
    //Doc: Application Under Test, lifecycle management. NUnit features which can be possibly used
    //Doc: Using automation element is a problem. Please log issue. Create a section on the website for this.
    [TestFixture]
    public class CreateCustomerTest
    {
        [Test]
        public void Create()
        {
            Application application = Application.Launch(@"..\..\..\SampleApplication\bin\debug\SampleApplication.exe");
            Window window = application.GetWindow("Dashboard", InitializeOption.NoCache);
            Hyperlink createCustomerLink = window.Get<Hyperlink>("createCustomer");
            createCustomerLink.Click();
            Window step1 = application.GetWindow("Create Customer Step1", InitializeOption.NoCache);
            step1.Get<TextBox>("nameTextBox").BulkText = "Rakesh Kumar";
            step1.Get<TextBox>("ageTextBox").BulkText = "26";
            step1.Get<Button>("nextButton").Click();
            Window step2 = application.GetWindow("Create Customer Step2", InitializeOption.NoCache);
            step2.Get<TextBox>("phoneNumberTextBox").BulkText = "123213213";
            step2.Get<Button>("submitButton").Click();
            application.Kill();
        }

        [Test]
        public void CreateCustomer_WithoutName()
        {
            Application application = Application.Launch(@"..\..\..\SampleApplication\bin\debug\SampleApplication.exe");
            Window window = application.GetWindow("Dashboard", InitializeOption.NoCache);
            Hyperlink createCustomerLink = window.Get<Hyperlink>("createCustomer");
            createCustomerLink.Click();
            Window step1 = application.GetWindow("Create Customer Step1", InitializeOption.NoCache);
            step1.Get<TextBox>("nameTextBox").BulkText = "Rakesh Kumar";
            step1.Get<Button>("nextButton").Click();
            Label messageLabel = step1.Get<Label>("messageLabel");
            Assert.AreEqual("/Age should be a valid number", messageLabel.Text);
            application.Kill();
        }
    }
}