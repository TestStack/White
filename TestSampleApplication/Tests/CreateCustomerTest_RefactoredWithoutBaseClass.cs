using Core;
using Core.Factory;
using Core.UIItems;
using Core.UIItems.WindowItems;
using NUnit.Framework;

namespace TestSampleApplication.Tests
{
    [TestFixture]
    public class CreateCustomerTest_RefactoredWithoutBaseClass
    {
        private Application application;
        private Window window;

        [SetUp]
        public void SetUp()
        {
            application = Application.Launch(@"..\..\..\SampleApplication\bin\debug\SampleApplication.exe");
            window = application.GetWindow("Dashboard", InitializeOption.NoCache);
        }

        [TearDown]
        public void CloseApplication()
        {
            if (application != null) application.Kill();
        }

        [Test]
        public void Create()
        {
            Window step1 = LaunchCreateCustomer();
            FillStep1(step1, "Rakesh Kumar", "26");
            Window step2 = application.GetWindow("Create Customer Step2", InitializeOption.NoCache);
            step2.Get<TextBox>("phoneNumberTextBox").BulkText = "123213213";
            step2.Get<Button>("submitButton").Click();
        }

        [Test]
        public void CreateCustomer_WithoutName()
        {
            Window step1 = LaunchCreateCustomer();
            FillStep1(step1, "Rakesh Kumar", "26");
            Label messageLabel = step1.Get<Label>("messageLabel");
            Assert.AreEqual("/Age should be a valid number", messageLabel.Text);
        }

        private void FillStep1(Window step1, string name, string age)
        {
            step1.Get<TextBox>("nameTextBox").BulkText = name;
            step1.Get<TextBox>("ageTextBox").BulkText = age;
            step1.Get<Button>("nextButton").Click();
        }

        private Window LaunchCreateCustomer()
        {
            Hyperlink createCustomerLink = window.Get<Hyperlink>("createCustomer");
            createCustomerLink.Click();
            return application.GetWindow("Create Customer Step1", InitializeOption.NoCache);
        }
    }
}