using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UIItems.MenuItems;

namespace White.Core.UITests.UIItems.WindowItems
{
    [TestFixture, WinFormCategory]
    public class WinFormWindowTest : WindowAbstractTest
    {
        [Fact]
        public void HandlesInvisibleControls()
        {
            var exception = Assert.Throws<AutomationException>(() => Window.Get<Label>("dynamicControl"));
            Assert.Equal("Failed to get ControlType=text,AutomationId=dynamicControl", exception.Message);

            Window.Get<Button>("invisibleControlShower").Click();
            Assert.NotEqual(null, Window.Get<Label>(SearchCriteria.ByAutomationId("dynamicControl")));
        }

        [Fact]
        public void FindToolBarsWhenThereAreMultiple()
        {
            Assert.NotEqual(null, Window.GetToolStrip("toolStrip1"));
            Assert.NotEqual(null, Window.GetToolStrip("toolStrip2"));
            var exception = Assert.Throws<AutomationException>(()=>Window.GetToolStrip("toolStrip3"));
            Assert.Equal("Failed to get AutomationId=toolStrip3", exception.Message);
        }

        [Fact]
        public void WindowScrollsToMakeItemVisibleBeforePerformingAnyAction()
        {
            Window.Get<Button>("hiddenButton").Click();
            Menu menu = Window.MenuBar.MenuItem("File", "Click Me");
            Assert.NotEqual(null, menu);
        }

        protected override TestConfiguration OtherConfiguration()
        {
            return new WPFTestConfiguration(string.Empty);
        }
    }
}