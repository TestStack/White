using System.Collections.Generic;
using NUnit.Framework;
using TestStack.White.UITests.Infrastructure;
using White.Core.UIItems.ListBoxItems;

namespace TestStack.White.UITests.ControlTests
{
    public class EditableComboBoxTests : WhiteTestBase
    {
        protected ComboBox ComboBoxUnderTest { get; set; }

        protected override void RunTest(FrameworkId framework)
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

        protected override IEnumerable<FrameworkId> SupportedFrameworks()
        {
            yield return FrameworkId.Wpf;
            yield return FrameworkId.Winforms;
        }
    }
}