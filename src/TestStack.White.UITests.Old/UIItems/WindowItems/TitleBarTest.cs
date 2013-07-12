using NUnit.Framework;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UITests.Testing;

namespace White.Core.UITests.UIItems.WindowItems
{
    public class TitleBarTest : ControlsActionTest
    {
        [Fact]
        public void Find()
        {
            TitleBar titleBar = Window.TitleBar;
            Assert.NotEqual(null, titleBar.MinimizeButton);
            Assert.NotEqual(null, titleBar.MaximizeButton);
            Assert.NotEqual(null, titleBar.CloseButton);
        }
    }
}