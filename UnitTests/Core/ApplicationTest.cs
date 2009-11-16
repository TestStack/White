using NUnit.Framework;
using White.Core.Factory;
using White.Core.Testing;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UIItems.WindowItems;

namespace White.Core
{
    [TestFixture]
    public class ApplicationTest : ControlsActionTest
    {
        [Test]
        public void GetWindows()
        {
            Assert.AreNotEqual(null, window);
        }

        [Test]
        public void GetAllWindows()
        {
            window.Get<Button>("launchModal").Click();
            int count = application.GetWindows().Count;
            CloseModal(window);
            Assert.AreEqual(2, count);
        }

        [Test]
        public void FindWindow()
        {
            window.Get<Button>("launchModal").Click();
            Window foundWindow = application.Find(obj => obj.Equals("ModalForm"), InitializeOption.NoCache);
            CloseModal(window);
            Assert.AreNotEqual(null, foundWindow);
        }
    }

    [TestFixture, WinFormCategory]
    public class WinFormApplicationTest : ControlsActionTest
    {
        [Test, WinFormCategory]
        public void GetWindowBasedOnFrameworkId()
        {
            Window frameworkWindow =
                application.GetWindow(SearchCriteria.ByText("Form1").AndOfFramework(ApplicationClass.WinForm.ToString()), InitializeOption.NoCache);
            Assert.AreNotEqual(null, frameworkWindow);
        }

        [Test, WinFormCategory]
        public void FindWindowBasedOnSearchCriteria()
        {
            Assert.AreNotEqual(null, application.GetWindow(SearchCriteria.ByAutomationId("Form1"), InitializeOption.NoCache));
        }
    }
}