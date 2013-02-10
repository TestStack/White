using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    [TestFixture, WinFormCategory, WPFCategory]
    public class ImageTest : ControlsActionTest
    {
        [Test]
        public void Click()
        {
            var image = Window.Get<Image>("image");
            Assert.AreNotEqual(null, image);
        }
    }
}