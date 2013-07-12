using NUnit.Framework;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UITests.Testing;

namespace White.Core.UITests
{
    [TestFixture, WinFormCategory]
    public class WinFormApplicationTest : ControlsActionTest
    {
        [Test, WinFormCategory]
        public void GetWindowBasedOnFrameworkId()
        {
            Window frameworkWindow = Application.GetWindow(SearchCriteria.ByText("Form1").AndOfFramework(WindowsFramework.WinForms), InitializeOption.NoCache);
            Assert.NotEqual(null, frameworkWindow);
        }

        [Test, WinFormCategory]
        public void FindWindowBasedOnSearchCriteria()
        {
            Assert.NotEqual(null, Application.GetWindow(SearchCriteria.ByAutomationId("Form1"), InitializeOption.NoCache));
        }
    }
}