using System.Collections.Generic;
using White.Core.UIItems;
using White.Core.UIItems.ListBoxItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests.ListControls
{
    public class EditableComboBoxTests : WhiteTestBase
    {
        protected ComboBox ComboBoxUnderTest { get; set; }

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            ComboBoxUnderTest = MainWindow.Get<ComboBox>("EditableComboBox");
            RunTest(SetValueInEditableComboBox);
            RunTest(SelectItemInEditableComboBox);
        }

        private void SetValueInEditableComboBox()
        {
            ComboBoxUnderTest.EditableText = "foobar";
            Assert.Equal("foobar", ComboBoxUnderTest.EditableText);
        }

        private void SelectItemInEditableComboBox()
        {
            ComboBoxUnderTest.Select("Test3");
            Assert.Equal("Test3", ComboBoxUnderTest.EditableText);
            Assert.Equal("Test3", ComboBoxUnderTest.SelectedItemText);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
        }
    }
}