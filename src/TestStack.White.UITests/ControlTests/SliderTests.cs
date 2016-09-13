using NUnit.Framework;
using TestStack.White.UIItems;

namespace TestStack.White.UITests.ControlTests
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class SliderTests : WhiteUITestBase
    {
        private Slider slider;

        public SliderTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [OneTimeSetUp]
        public void Setup()
        {
            SelectOtherControls();
            slider = MainWindow.Get<Slider>("Slider");
        }

        [Test]
        public void SetValueTest()
        {
            slider.Value = 5;
            Assert.That(slider.Value, Is.EqualTo(5));
        }

        [Test]
        public void LargeIncrementTest()
        {
            slider.Value = 5;
            slider.LargeIncrementButton.Click();
            Assert.That(slider.Value, Is.EqualTo(9));
        }

        [Test]
        public void LargeDecrementTest()
        {
            slider.Value = 5;
            slider.LargeDecrementButton.Click();
            Assert.That(slider.Value, Is.EqualTo(1));
        }

        [Test]
        public void SmallIncrementTest()
        {
            slider.Value = 5;
            slider.SmallIncrement();
            Assert.That(slider.Value, Is.EqualTo(6));
        }

        [Test]
        public void SmallDecrementTest()
        {
            slider.Value = 5;
            slider.SmallDecrement();
            Assert.That(slider.Value, Is.EqualTo(4));
        }
    }
}