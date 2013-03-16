using System.Collections.Generic;
using NUnit.Framework;
using White.Core.UIItems;

namespace TestStack.White.UITests.ControlTests
{
    public class CheckboxTest : WhiteTestBase
    {
        protected override void RunTest(WindowsFramework framework)
        {
            RunTest(SelectUnselect);
            RunTest(CheckAndUncheckCheckbox);
        }

        private void SelectUnselect()
        {
            var checkBox = MainWindow.Get<CheckBox>("CheckBox");
            Assert.False(checkBox.IsSelected);
            Assert.False(checkBox.Checked);
            checkBox.Select();
            Assert.True(checkBox.IsSelected);
            Assert.True(checkBox.Checked);
            checkBox.UnSelect();
            Assert.False(checkBox.IsSelected);
            Assert.False(checkBox.Checked);
        }

        private void CheckAndUncheckCheckbox()
        {
            var checkBox = MainWindow.Get<CheckBox>("CheckBox");
            Assert.False(checkBox.Checked);

            checkBox.Checked = true;
            Assert.True(checkBox.Checked);


            checkBox.Checked = false;
            Assert.False(checkBox.Checked);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
        }
    }
}