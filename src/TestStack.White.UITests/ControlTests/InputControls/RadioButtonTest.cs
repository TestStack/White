using System.Collections.Generic;
using TestStack.White.UIItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests.InputControls
{
    public class RadioButtonTest : WhiteTestBase
    {
        void SelectSingleRadioButton()
        {
            var radioButton = MainWindow.Get<RadioButton>("RadioButton1");
            Assert.False(radioButton.IsSelected);
            radioButton.Select();
            Assert.True(radioButton.IsSelected);
        }

        void SelectRadioButtonGroup()
        {
            var radioButton1 = MainWindow.Get<RadioButton>("RadioButton1");
            var radioButton2 = MainWindow.Get<RadioButton>("RadioButton2");

            Assert.False(radioButton1.IsSelected && radioButton2.IsSelected);

            radioButton1.Select();
            Assert.True(radioButton1.IsSelected);
            Assert.False(radioButton2.IsSelected);

            radioButton2.Select();

            Assert.False(radioButton1.IsSelected);
            // ReSharper disable once HeuristicUnreachableCode
            Assert.True(radioButton2.IsSelected);
        }

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            RunTest(SelectSingleRadioButton);
            RunTest(SelectRadioButtonGroup);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
        }
    }
}