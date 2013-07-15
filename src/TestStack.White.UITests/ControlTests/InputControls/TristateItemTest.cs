using System.Collections.Generic;
using System.Windows.Automation;
using TestStack.White.UIItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests.InputControls
{
    public class TristateItemTest : WhiteTestBase
    {
        void TristateCheckbox()
        {
            SelectInputControls();
            var checkBox = MainWindow.Get<CheckBox>("TriStateCheckBox");
            Assert.Equal(ToggleState.Indeterminate, checkBox.State);
            checkBox.State = ToggleState.On;
            Assert.Equal(ToggleState.On, checkBox.State);
            checkBox.State = ToggleState.Off;
            Assert.Equal(ToggleState.Off, checkBox.State);
        }

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            RunTest(TristateCheckbox);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
        }
    }
}