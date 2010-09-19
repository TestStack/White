using NUnit.Framework;
using White.Core.UIItems.WindowItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems.WindowItems
{
    [TestFixture]
    public class TitleBarTest : ControlsActionTest
    {
        [Test]
        public void Find()
        {
            TitleBar titleBar = window.TitleBar;
            Assert.AreNotEqual(null, titleBar.MinimizeButton);
            Assert.AreNotEqual(null, titleBar.MaximizeButton);
            Assert.AreNotEqual(null, titleBar.CloseButton);
        }
    }
}