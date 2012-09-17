using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UIItems.Scrolling;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    [TestFixture]
    public class HScrollBarTest : ControlsActionTest
    {
        private IHScrollBar hScrollBar;
        private double largeChange;

        protected override void TestFixtureSetUp()
        {
            var textBox = window.Get<MultilineTextBox>("textBox1");
            hScrollBar = textBox.ScrollBars.Horizontal;
            hScrollBar.ScrollRightLarge();
            largeChange = hScrollBar.Value;
            hScrollBar.ScrollLeftLarge();
        }

        [Test]
        public void ShouldGetHScrollBar()
        {
            Assert.IsNotNull(hScrollBar);
        }

        [Test]
        public void ShouldScrollRight()
        {
            double initialValue = hScrollBar.Value;
            hScrollBar.ScrollRight();
            Assert.AreEqual(true, hScrollBar.Value > initialValue);
        }

        [Test]
        public void ShouldScrollRightLarge()
        {
            double initialValue = hScrollBar.Value;
            hScrollBar.ScrollRightLarge();
            Assert.AreEqual(true, hScrollBar.Value > initialValue);
        }

        [Test]
        public void ShouldScrollLeft()
        {
            hScrollBar.ScrollRightLarge();
            double valueBeforeScrollLeft = hScrollBar.Value;
            hScrollBar.ScrollLeft();
            Assert.AreEqual(true, valueBeforeScrollLeft > hScrollBar.Value, hScrollBar.Value.ToString());
        }

        [Ignore("This causes visual studio to crash")]
        public void ShouldScrollLeftLarge()
        {
//            hScrollBar.Value = 50;
            hScrollBar.ScrollLeftLarge();
            hScrollBar.ScrollLeftLarge();
            hScrollBar.ScrollLeftLarge();
            Assert.AreEqual(50 - (largeChange*3), hScrollBar.Value);
        }
    }
}