using Core.Factory;
using Core.UIItems;
using Core.UIItems.WindowItems;
using NUnit.Framework;
using TestSampleApplication.Entities;
using TestSampleApplication.Screens;

namespace TestSampleApplication.Tests
{
    [TestFixture]
    public class IssueMovieTest : VideoLibraryTest
    {
        [Test]
        public void Issue_Movie_To_An_Existing_Customer()
        {
            Window searchWindow = LaunchSearchCustomer();
            searchWindow.Get<TextBox>("nameTextBox").Text = "Suman";
            searchWindow.Get<Button>("search").Click();

            Hyperlink searchMoviesLink = window.Get<Hyperlink>("searchMovies");
            searchMoviesLink.Click();
            
            Window searchMovieWindow = searchWindow.ModalWindow("Search Movies", InitializeOption.NoCache);
            searchMovieWindow.Get<TextBox>("nameTextbox").Text = "Taare";
            searchMovieWindow.Get<Button>("search").Click();
            searchMovieWindow.Get<Button>("select").Click();

            searchWindow.Get<Button>("ok").Click();
        }

        private Window LaunchSearchCustomer()
        {
            Hyperlink searchCustomerLink = window.Get<Hyperlink>("searchCustomer");
            searchCustomerLink.Click();
            return window.ModalWindow("Search Customer", InitializeOption.NoCache);
        }

        [Test, Ignore]
        public void IssueMovie()
        {
            Window step1 = LaunchCreateCustomer();
            FillStep1(step1, "Rakesh Kumar", "26");
        }

        [Test, Ignore]
        public void IssueMovie_AnotherTry()
        {
            DashboardScreen dashboardScreen = new DashboardScreen(window, application);
            Customer customer = new Customer("Rakesh Kumar", "26", "34343545");
            CreateCustomerStep1Screen step1Screen = dashboardScreen.LaunchCreateCustomer();
            step1Screen.FillAndNext(customer);
        }

        private Window LaunchCreateCustomer()
        {
            Hyperlink createCustomerLink = window.Get<Hyperlink>("createCustomer");
            createCustomerLink.Click();
            return application.GetWindow("Create Customer Step1", InitializeOption.NoCache);
        }

        private void FillStep1(Window step1, string name, string age)
        {
            step1.Get<TextBox>("nameTextBox").BulkText = name;
            step1.Get<TextBox>("ageTextBox").BulkText = age;
            step1.Get<Button>("nextButton").Click();
        }
    }
}