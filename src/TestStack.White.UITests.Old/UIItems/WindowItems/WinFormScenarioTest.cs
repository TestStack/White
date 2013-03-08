using System.Windows.Automation;
using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems.WindowItems
{
    [TestFixture, WinFormCategory]
    public class WinFormScenarioTest : ControlsActionTest
    {
        [Test]
        public void GetMultiplePanes()
        {
            IUIItem pane = Window.Get(SearchCriteria.ByControlType(ControlType.Pane).AndAutomationId("panelWithText"));
            Assert.AreNotEqual(null, pane);
            IUIItem[] multiple = Window.GetMultiple(SearchCriteria.ByControlType(ControlType.Pane).AndAutomationId("panelWithText"));
            Assert.AreNotEqual(0, multiple.Length);
        }
    }
}