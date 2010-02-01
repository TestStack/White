using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UIItems.WindowItems;
using White.UnitTests.Core.Testing;

namespace White.Core
{
    [TestFixture, WinFormCategory, SWTCategory]
    public class ModalWindowTest : ControlsActionTest
    {
        [TearDown]
        public void TearDown()
        {
            CloseModal(window);
        }

        [Test]
        public void NoModalWindowExists()
        {
            Window modalWindow = window.ModalWindow("foo");
            Assert.AreEqual(null, modalWindow);
        }

        [Test]
        public void GetModalWindow()
        {
            LaunchModalWindow();
            Window modalWindow = window.ModalWindow("ModalForm");
            Assert.AreNotEqual(null, modalWindow);
        }

        private void LaunchModalWindow()
        {
            window.Get<Button>("launchModal").Click();
        }

        [Test]
        public void GetModalWindowBasedOnSearchCriteria()
        {
            LaunchModalWindow();
            Window modalWindow = window.ModalWindow(SearchCriteria.ByText("ModalForm"));
            Assert.AreNotEqual(null, modalWindow);
        }
    }
}