using NUnit.Framework;
using White.UnitTests.Core.Testing;

namespace White.Core.UIItems.WindowItems
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