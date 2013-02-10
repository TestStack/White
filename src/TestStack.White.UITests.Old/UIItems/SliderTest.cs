using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    [TestFixture, WinFormCategory, WPFCategory]
    public class SliderTest : ControlsActionTest
    {
        private Slider slider;

        protected override void TestFixtureSetUp()
        {
            slider = Window.Get<Slider>("slider1");
        }

        [SetUp]
        public void SetUp()
        {
            slider.Value = 4;
        }

        [Test]
        public void Value()
        {
            Assert.AreEqual(4, slider.Value);
        }

        [Test]
        public void SetValue()
        {
            slider.Value = 5;
            Assert.AreEqual(5, slider.Value);
        }

        [Test]
        public void LargeIncrement()
        {
            slider.LargeIncrementButton.Click();
            Assert.AreEqual(4 + slider.LargeChangeAmount, slider.Value);
        }

        [Test]
        public void LargeDecrement()
        {
            slider.LargeDecrementButton.Click();
            Assert.AreEqual(4 - slider.LargeChangeAmount, slider.Value);
        }

        [Test]
        public void SmallIncrement()
        {
            slider.SmallIncrement();
            Assert.AreEqual(4 + slider.SmallChangeAmount, slider.Value);
        }

        [Test]
        public void SmallDecrement()
        {
            slider.SmallDecrement();
            Assert.AreEqual(4 - slider.SmallChangeAmount, slider.Value);
        }
    }
}