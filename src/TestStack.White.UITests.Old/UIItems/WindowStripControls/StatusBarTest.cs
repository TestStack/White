using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowStripControls;
using TestStack.White.UITests.Testing;

namespace White.Core.UITests.UIItems.WindowStripControls
{
    [TestFixture, WPFCategory]
    public class StatusBarTest : ControlsActionTest
    {
        private WPFStatusBar statusBar;

        protected override void TestFixtureSetUp()
        {
            statusBar = Window.Get<WPFStatusBar>("statusBar1");
        }

        [Fact]
        public void StatusBar()
        {
            Assert.NotEqual(null, statusBar);
        }

        [Fact]
        public void StatusBarItem()
        {
            UIItemCollection collection = statusBar.Items;
            Assert.Equal(2, collection.Count);
            var label = (Label) collection[0];
            Assert.Equal("Status Item 1", label.Text);
        }
    }
}