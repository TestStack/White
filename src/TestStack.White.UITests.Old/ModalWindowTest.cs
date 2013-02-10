using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UIItems.WindowItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests
{
    [TestFixture, WinFormCategory/*, SWTCategory*/] //TODO Get SWT working
    public class ModalWindowTest : ControlsActionTest
    {
        [TearDown]
        public void TearDown()
        {
            CloseModal(Window);
        }

        [Test]
        public void NoModalWindowExists()
        {
            Window modalWindow = Window.ModalWindow("foo");
            Assert.AreEqual(null, modalWindow);
        }

        [Test]
        public void GetModalWindow()
        {
            LaunchModalWindow();
            Window modalWindow = Window.ModalWindow("ModalForm");
            Assert.AreNotEqual(null, modalWindow);
        }

        private void LaunchModalWindow()
        {
            Window.Get<Button>("launchModal").Click();
        }

        [Test]
        public void GetModalWindowBasedOnSearchCriteria()
        {
            LaunchModalWindow();
            Window modalWindow = Window.ModalWindow(SearchCriteria.ByText("ModalForm"));
            Assert.AreNotEqual(null, modalWindow);
        }
    }
}