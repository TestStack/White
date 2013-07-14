using System.Collections.Generic;
using TestStack.White.UIItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests.InputControls
{
    public class SpinnerTest : WhiteTestBase
    {
        private Spinner spinner;

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            SelectInputControls();
            spinner = MainWindow.Get<Spinner>("NumericUpDown");
            RunTest(Value);
            RunTest(Increment);
            RunTest(Decrement);
        }

        void Increment()
        {
            spinner.Value = 4.0;
            spinner.Increment();
            Assert.Equal(4.2, spinner.Value);
        }

        void Value()
        {
            spinner.Value = 4.0;
            Assert.Equal(4, spinner.Value);
        }

        void Decrement()
        {
            spinner.Value = 4.0;
            spinner.Decrement();
            Assert.Equal(3.8, spinner.Value);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.WinForms;
        }
    }
}