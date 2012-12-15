using NUnit.Framework;
using White.Core.UIItems;

namespace White.Core.UITests.UIItems.WindowItems
{
    [TestFixture, WPFCategory]
    public class WPFWindowTest : WindowAbstractTest
    {
        [Test]
        public void HandlesInvisibleControls()
        {
            var label = window.Get<Label>("dynamicControl");
            Assert.AreEqual(false, label.Visible);
            window.Get<Button>("invisibleControlShower").Click();
            Assert.AreEqual(true, label.Visible);
        }

        protected override TestConfiguration OtherConfiguration()
        {
            return new WinFormTestConfiguration(string.Empty);
        }
    }
}