using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UIItems.ListBoxItems;
using White.Core.UIItems.TreeItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    [TestFixture, WPFCategory]
    public class AbstractScrollBarsTest : ControlsActionTest
    {
        [Test]
        public void CanScroll()
        {
            var controlWithVScrollBar = Window.Get<ListBox>("listBoxWithVScrollBar");
            Assert.AreEqual(true, controlWithVScrollBar.ScrollBars.CanScroll);
            var controlWithHorizontalScrollBar = Window.Get<MultilineTextBox>("textBox1");
            Assert.AreEqual(true, controlWithHorizontalScrollBar.ScrollBars.CanScroll);
        }

        [Test]
        public void CannotScroll()
        {
            var controlWithScrollBar = Window.Get<Tree>("treeViewLaunchesModal");
            Assert.AreEqual(false, controlWithScrollBar.ScrollBars.CanScroll);
        }
    }
}
