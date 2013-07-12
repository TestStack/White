using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    [TestFixture, WinFormCategory, WPFCategory]
    public class ImageTest : ControlsActionTest
    {
        [Fact]
        public void Click()
        {
            var image = Window.Get<Image>("image");
            Assert.NotEqual(null, image);
        }
    }
}