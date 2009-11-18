using NUnit.Framework;
using White.Core.Testing;

namespace White.Core.UIItems
{
    [TestFixture, WinFormCategory, WPFCategory]
    public class ImageTest : ControlsActionTest
    {
        [Test]
        public void Click()
        {
            var image = window.Get<Image>("image");
            Assert.AreNotEqual(null, image);
        }
    }
}