using NUnit.Framework;
using White.Core.UIItems.Finders;
using White.Core.UIItems.MenuItems;

namespace White.Core.UIItems.WindowItems
{
    [TestFixture, WinFormCategory]
    public class WinFormWindowTest : WindowAbstractTest
    {
        [Test]
        public void HandlesInvisibleControls()
        {
            Assert.AreEqual(null, window.Get<Label>("dynamicControl"));
            window.Get<Button>("invisibleControlShower").Click();
            Assert.AreNotEqual(null, window.Get<Label>(SearchCriteria.ByAutomationId("dynamicControl")));
        }

        [Test]
        public void FindToolBarsWhenThereAreMultiple()
        {
            Assert.AreNotEqual(null, window.GetToolStrip("toolStrip1"));
            Assert.AreNotEqual(null, window.GetToolStrip("toolStrip2"));
            Assert.AreEqual(null, window.GetToolStrip("toolStrip3"));
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