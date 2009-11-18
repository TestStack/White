using NUnit.Framework;
using White.Core.Testing;

namespace White.Core.UIItems
{
    [TestFixture, WinFormCategory, WPFCategory]
    public class HorizontalThumbTest : ControlsActionTest
    {
        protected override string CommandLineArguments
        {
            get { return HorizontalGridSplitter; }
        }

        [Test]
        public void Find()
        {
            var thumb = window.Get<Thumb>("splitter");
            Assert.AreNotEqual(null, thumb);
        }

        [Test]
        public void Slide()
        {
            var thumb = window.Get<Thumb>("splitter");
            double originalX = thumb.Location.X;
            thumb.SlideHorizontally(50);
            Assert.AreEqual(originalX + 50, thumb.Location.X);
        }
    }
}