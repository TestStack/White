using Core.Factory;
using Core.UIItems;
using Core.UIItems.TableItems;
using Core.UIItems.WindowItems;
using NUnit.Framework;

namespace TestSampleApplication.Tests
{
    [TestFixture]
    public class SearchCustomerTest : VideoLibraryTest
    {
        [Test]
        public void SearchByName()
        {
            Window searchWindow = LaunchSearchCustomer();
            searchWindow.Get<TextBox>("nameTextBox").Text = "Suman";
            searchWindow.Get<Button>("search").Click();
            Assert.AreEqual(1, searchWindow.Get<Table>("foundCustomers").Rows.Count);
        }

        [Test]
        public void SearchByAge()
        {
            Window searchWindow = LaunchSearchCustomer();
            searchWindow.Get<TextBox>("ageTextBox").Text = "20";
            searchWindow.Get<Button>("search").Click();
            Assert.AreEqual(1, searchWindow.Get<Table>("foundCustomers").Rows.Count);            
        }

        private Window LaunchSearchCustomer()
        {
            Hyperlink searchCustomerLink = window.Get<Hyperlink>("searchCustomer");
            searchCustomerLink.Click();
            return window.ModalWindow("Search Customer", InitializeOption.NoCache);
        }
    }
}