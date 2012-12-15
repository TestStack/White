using System.Windows.Automation;
using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UIItems.WindowItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems.WindowItems
{
    [TestFixture, NormalCategory]
    public class UIItemContainerScenarioTest
    {
        //TODO: Create an MDI application for testing.
        [Test, Ignore]
        public void FindContainer()
        {
            Window window = Desktop.Instance.Windows().Find(obj => obj.Title.Contains("Microsoft Visual Studio"));
            if (window == null) return;

            window.MdiChild(SearchCriteria.ByControlType(ControlType.Pane).AndByText("UIItemContainerTest.cs"));
        }
    }

    [TestFixture, WPFCategory]
    public class UIItemContainerTest : ControlsActionTest
    {
        [Test]
        public void GetMultiple()
        {
            IUIItem[] buttons = window.GetMultiple(SearchCriteria.ByControlType(typeof(Button)));
            Assert.AreEqual(true, buttons.Length > 10);
        }
    }

    [TestFixture, WinFormCategory]
    public class WinFormScenarioTest : ControlsActionTest
    {
        [Test]
        public void GetMultiplePanes()
        {
            IUIItem pane = window.Get(SearchCriteria.ByControlType(ControlType.Pane).AndAutomationId("panelWithText"));
            Assert.AreNotEqual(null, pane);
            IUIItem[] multiple = window.GetMultiple(SearchCriteria.ByControlType(ControlType.Pane).AndAutomationId("panelWithText"));
            Assert.AreNotEqual(0, multiple.Length);
        }
    }
}