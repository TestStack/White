using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UIItems.MenuItems;

namespace White.Core.UITests.UIItems.WindowItems
{
    [TestFixture, WinFormCategory]
    public class WinFormWindowTest : WindowAbstractTest
    {
        [Test]
        public void HandlesInvisibleControls()
        {
            var exception = Assert.Throws<AutomationException>(() => Window.Get<Label>("dynamicControl"));
            Assert.AreEqual("Failed to get ControlType=text,AutomationId=dynamicControl", exception.Message);

            Window.Get<Button>("invisibleControlShower").Click();
            Assert.AreNotEqual(null, Window.Get<Label>(SearchCriteria.ByAutomationId("dynamicControl")));
        }

        [Test]
        public void FindToolBarsWhenThereAreMultiple()
        {
            Assert.AreNotEqual(null, Window.GetToolStrip("toolStrip1"));
            Assert.AreNotEqual(null, Window.GetToolStrip("toolStrip2"));
            var exception = Assert.Throws<AutomationException>(()=>Window.GetToolStrip("toolStrip3"));
            Assert.AreEqual("Failed to get AutomationId=toolStrip3", exception.Message);
        }

        [Test]
        public void WindowScrollsToMakeItemVisibleBeforePerformingAnyAction()
        {
            Window.Get<Button>("hiddenButton").Click();
            Menu menu = Window.MenuBar.MenuItem("File", "Click Me");
            Assert.AreNotEqual(null, menu);
        }

        protected override TestConfiguration OtherConfiguration()
        {
            return new WPFTestConfiguration(string.Empty);
        }
    }
}