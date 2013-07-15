using System.Collections.Generic;
using TestStack.White.UIItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests
{
    public class SliderTest : WhiteTestBase
    {
        private Slider slider;

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            SelectOtherControls();
            slider = MainWindow.Get<Slider>("Slider");

            RunTest(SetValue);
            RunTest(LargeIncrement);
            RunTest(LargeDecrement);
            RunTest(SmallIncrement);
            RunTest(SmallDecrement);
        }

        void SetValue()
        {
            slider.Value = 5;
            Assert.Equal(5, slider.Value);
        }

        void LargeIncrement()
        {
            slider.Value = 5;
            slider.LargeIncrementButton.Click();
            Assert.Equal(9, slider.Value);
        }

        void LargeDecrement()
        {
            slider.Value = 5;
            slider.LargeDecrementButton.Click();
            Assert.Equal(1, slider.Value);
        }

        void SmallIncrement()
        {
            slider.Value = 5;
            slider.SmallIncrement();
            Assert.Equal(6, slider.Value);
        }

        void SmallDecrement()
        {
            slider.Value = 5;
            slider.SmallDecrement();
            Assert.Equal(4, slider.Value);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
        }
    }
}