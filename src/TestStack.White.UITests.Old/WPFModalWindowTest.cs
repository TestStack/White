using NUnit.Framework;
using White.Core.Factory;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UIItems.WindowItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests
{
    public class WPFModalWindowTest : CoreTestTemplate
    {
        private Window window;
        protected override string CommandLineArguments
        {
            get { return "setowner"; }
        }

        [TearDown]
        public void TearDown()
        {
            CloseModal(window);
        }

        [Fact]
        public void FindModalWindow()
        {
            window = Application.GetWindow("Form1", InitializeOption.NoCache);
            window.Get<Button>("launchModal").Click();
            Assert.Equal(false, window.IsModal);
        }

        [Fact]
        public void FindModalWindowBasedOnSearchCriteria()
        {
            window = Application.GetWindow("Form1", InitializeOption.NoCache);
            window.Get<Button>("launchModal").Click();
            Window modalWindow = window.ModalWindow(SearchCriteria.ByText("ModalForm"), InitializeOption.NoCache);
            Assert.NotEqual(null, modalWindow);
        }

        [Fact]
        public void FindModalWindowBasedOnSearchCriteriaWhenThereIsNoWindow()
        {
            window = Application.GetWindow("Form1", InitializeOption.NoCache);
            window.Get<Button>("launchModal").Click();
            Window modalWindow = window.ModalWindow(SearchCriteria.ByText("ModalForm1"), InitializeOption.NoCache);
            Assert.Equal(null, modalWindow);
        }

        public override void TextFixtureTearDown()
        {
            Application.Kill();
        }
    }
}