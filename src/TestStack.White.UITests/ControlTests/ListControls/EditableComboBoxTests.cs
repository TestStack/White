using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;

namespace TestStack.White.UITests.ControlTests.ListControls
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class EditableComboBoxTests : WhiteUITestBase
    {
        protected ComboBox ComboBoxUnderTest { get; set; }

        public EditableComboBoxTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [OneTimeSetUp]
        public void Setup()
        {
            ComboBoxUnderTest = MainWindow.Get<ComboBox>("EditableComboBox");
        }

        [Test]
        public void SetValueInEditableComboBoxTest()
        {
            ComboBoxUnderTest.EditableText = "foobar";
            Assert.That(ComboBoxUnderTest.EditableText, Is.EqualTo("foobar"));
        }

        [Test]
        [Category("NeedsFix")]
        [Ignore("NeedsFix")]
        public void SelectItemInEditableComboBoxTest()
        {
            ComboBoxUnderTest.Select("Test3");
            Assert.That(ComboBoxUnderTest.EditableText, Is.EqualTo("Test3"));
            Assert.That(ComboBoxUnderTest.SelectedItemText, Is.EqualTo("Test3"));
        }
    }
}