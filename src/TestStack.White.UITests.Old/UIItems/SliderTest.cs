using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UITests.Testing;

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

        [Fact]
        public void Value()
        {
            Assert.Equal(4, slider.Value);
        }

        [Fact]
        public void SetValue()
        {
            slider.Value = 5;
            Assert.Equal(5, slider.Value);
        }

        [Fact]
        public void LargeIncrement()
        {
            slider.LargeIncrementButton.Click();
            Assert.Equal(4 + slider.LargeChangeAmount, slider.Value);
        }

        [Fact]
        public void LargeDecrement()
        {
            slider.LargeDecrementButton.Click();
            Assert.Equal(4 - slider.LargeChangeAmount, slider.Value);
        }

        [Fact]
        public void SmallIncrement()
        {
            slider.SmallIncrement();
            Assert.Equal(4 + slider.SmallChangeAmount, slider.Value);
        }

        [Fact]
        public void SmallDecrement()
        {
            slider.SmallDecrement();
            Assert.Equal(4 - slider.SmallChangeAmount, slider.Value);
        }
    }
}