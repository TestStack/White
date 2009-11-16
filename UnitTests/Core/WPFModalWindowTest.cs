using NUnit.Framework;
using White.Core.Factory;
using White.Core.Testing;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UIItems.WindowItems;

namespace White.Core
{
    [TestFixture, WPFCategory]
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

        [Test]
        public void FindModalWindow()
        {
            window = application.GetWindow("Form1", InitializeOption.NoCache);
            window.Get<Button>("launchModal").Click();
            Assert.AreEqual(false, window.IsModal);
        }

        [Test]
        public void FindModalWindowBasedOnSearchCriteria()
        {
            window = application.GetWindow("Form1", InitializeOption.NoCache);
            window.Get<Button>("launchModal").Click();
            Window modalWindow = window.ModalWindow(SearchCriteria.ByText("ModalForm"), InitializeOption.NoCache);
            Assert.AreNotEqual(null, modalWindow);
        }

        [Test]
        public void FindModalWindowBasedOnSearchCriteriaWhenThereIsNoWindow()
        {
            window = application.GetWindow("Form1", InitializeOption.NoCache);
            window.Get<Button>("launchModal").Click();
            Window modalWindow = window.ModalWindow(SearchCriteria.ByText("ModalForm1"), InitializeOption.NoCache);
            Assert.AreEqual(null, modalWindow);
        }

        public override void TextFixtureTearDown()
        {
            application.Kill();
        }
    }
}