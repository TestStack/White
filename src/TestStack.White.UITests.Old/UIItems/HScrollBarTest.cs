using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UIItems.Scrolling;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    public class HScrollBarTest : ControlsActionTest
    {
        private IHScrollBar hScrollBar;
        private double largeChange;

        protected override void TestFixtureSetUp()
        {
            var textBox = Window.Get<MultilineTextBox>("textBox1");
            hScrollBar = textBox.ScrollBars.Horizontal;
            hScrollBar.ScrollRightLarge();
            largeChange = hScrollBar.Value;
            hScrollBar.ScrollLeftLarge();
        }

        [Fact]
        public void ShouldGetHScrollBar()
        {
            Assert.IsNotNull(hScrollBar);
        }

        [Fact]
        public void ShouldScrollRight()
        {
            double initialValue = hScrollBar.Value;
            hScrollBar.ScrollRight();
            Assert.Equal(true, hScrollBar.Value > initialValue);
        }

        [Fact]
        public void ShouldScrollRightLarge()
        {
            double initialValue = hScrollBar.Value;
            hScrollBar.ScrollRightLarge();
            Assert.Equal(true, hScrollBar.Value > initialValue);
        }

        [Fact]
        public void ShouldScrollLeft()
        {
            hScrollBar.ScrollRightLarge();
            double valueBeforeScrollLeft = hScrollBar.Value;
            hScrollBar.ScrollLeft();
            Assert.Equal(true, valueBeforeScrollLeft > hScrollBar.Value, hScrollBar.Value.ToString());
        }

        [Ignore("This causes visual studio to crash")]
        public void ShouldScrollLeftLarge()
        {
//            hScrollBar.Value = 50;
            hScrollBar.ScrollLeftLarge();
            hScrollBar.ScrollLeftLarge();
            hScrollBar.ScrollLeftLarge();
            Assert.Equal(50 - (largeChange*3), hScrollBar.Value);
        }
    }
}