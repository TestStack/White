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
            var exception = Assert.Throws<AutomationException>(() => window.Get<Label>("dynamicControl"));
            Assert.AreEqual("Failed to get ControlType=text,AutomationId=dynamicControl", exception.Message);

            window.Get<Button>("invisibleControlShower").Click();
            Assert.AreNotEqual(null, window.Get<Label>(SearchCriteria.ByAutomationId("dynamicControl")));
        }

        [Test]
        public void FindToolBarsWhenThereAreMultiple()
        {
            Assert.AreNotEqual(null, window.GetToolStrip("toolStrip1"));
            Assert.AreNotEqual(null, window.GetToolStrip("toolStrip2"));
            var exception = Assert.Throws<AutomationException>(()=>window.GetToolStrip("toolStrip3"));
            Assert.AreEqual("Failed to get AutomationId=toolStrip3", exception.Message);
        }

        [Test]
        public void WindowScrollsToMakeItemVisibleBeforePerformingAnyAction()
        {
            window.Get<Button>("hiddenButton").Click();
            Menu menu = window.MenuBar.MenuItem("File", "Click Me");
            Assert.AreNotEqual(null, menu);
        }

        protected override TestConfiguration OtherConfiguration()
        {
            return new WPFTestConfiguration(string.Empty);
        }
    }
}