using System.Collections.Generic;
using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UIItems.ListBoxItems;

namespace TestStack.White.UITests.ControlTests
{
    public class EditableComboBoxTests : WhiteTestBase
    {
        protected ComboBox ComboBoxUnderTest { get; set; }

        protected override void RunTest(WindowsFramework framework)
        {
            ComboBoxUnderTest = MainWindow.Get<ComboBox>("EditableComboBox");
            RunTest(SetValueInEditableComboBox);
            RunTest(SelectItemInEditableComboBox);
        }

        private void SetValueInEditableComboBox()
        {
            ComboBoxUnderTest.EditableText = "foobar";
            Assert.AreEqual("foobar", ComboBoxUnderTest.EditableText);
        }

        private void SelectItemInEditableComboBox()
        {
            ComboBoxUnderTest.Select("Test3");
            Assert.AreEqual("Test3", ComboBoxUnderTest.EditableText);
            Assert.AreEqual("Test3", ComboBoxUnderTest.SelectedItemText);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
        }
    }
}