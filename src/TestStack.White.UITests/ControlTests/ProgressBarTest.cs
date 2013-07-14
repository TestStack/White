using System.Collections.Generic;
using TestStack.White.UIItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests
{
    public class ProgressBarTest : WhiteTestBase
    {
        void MinimumValue()
        {
            var bar = MainWindow.Get<ProgressBar>("ProgressBar");
            Assert.Equal(0, bar.Minimum);
        }

        void MaximumValue()
        {
            var bar = MainWindow.Get<ProgressBar>("ProgressBar");
            Assert.Equal(100, bar.Maximum);
        }

        void Value()
        {
            var bar = MainWindow.Get<ProgressBar>("ProgressBar");
            Assert.Equal(50, bar.Value);
        }

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            SelectOtherControls();
            RunTest(MinimumValue);
            RunTest(MaximumValue);
            RunTest(Value);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
        }
    }
}