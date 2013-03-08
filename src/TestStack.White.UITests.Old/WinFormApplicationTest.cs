using NUnit.Framework;
using White.Core.Factory;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UIItems.WindowItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests
{
    [TestFixture, WinFormCategory]
    public class WinFormApplicationTest : ControlsActionTest
    {
        [Test, WinFormCategory]
        public void GetWindowBasedOnFrameworkId()
        {
            Window frameworkWindow = Application.GetWindow(SearchCriteria.ByText("Form1").AndOfFramework(WindowsFramework.WinForms), InitializeOption.NoCache);
            Assert.AreNotEqual(null, frameworkWindow);
        }

        [Test, WinFormCategory]
        public void FindWindowBasedOnSearchCriteria()
        {
            Assert.AreNotEqual(null, Application.GetWindow(SearchCriteria.ByAutomationId("Form1"), InitializeOption.NoCache));
        }
    }
}