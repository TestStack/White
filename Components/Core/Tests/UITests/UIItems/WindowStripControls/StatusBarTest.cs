using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UIItems.WindowStripControls;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems.WindowStripControls
{
    [TestFixture, WPFCategory]
    public class StatusBarTest : ControlsActionTest
    {
        private WPFStatusBar statusBar;

        protected override void TestFixtureSetUp()
        {
            statusBar = window.Get<WPFStatusBar>("statusBar1");
        }

        [Test]
        public void StatusBar()
        {
            Assert.AreNotEqual(null, statusBar);
        }

        [Test]
        public void StatusBarItem()
        {
            UIItemCollection collection = statusBar.Items;
            Assert.AreEqual(2, collection.Count);
            var label = (Label) collection[0];
            Assert.AreEqual("Status Item 1", label.Text);
        }
    }
}