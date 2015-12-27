using NUnit.Framework;
using TestStack.White.UIItems;

namespace TestStack.White.UITests.ControlTests.InputControls
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class CheckboxTests : WhiteUITestBase
    {
        public CheckboxTests(WindowsFramework framework)
            : base(framework) { }

        [OneTimeSetUp]
        public void Setup()
        {
            SelectInputControls();
        }

        [Test]
        public void SelectUnselect()
        {
            var checkBox = MainWindow.Get<CheckBox>("CheckBox");
            Assert.That(checkBox.IsSelected, Is.False);
            Assert.That(checkBox.Checked, Is.False);
            checkBox.Select();
            Assert.That(checkBox.IsSelected, Is.True);
            Assert.That(checkBox.Checked, Is.True);
            checkBox.UnSelect();
            Assert.That(checkBox.IsSelected, Is.False);
            Assert.That(checkBox.Checked, Is.False);
        }

        [Test]
        public void CheckAndUncheckCheckbox()
        {
            var checkBox = MainWindow.Get<CheckBox>("CheckBox");
            Assert.That(checkBox.Checked, Is.False);
            checkBox.Checked = true;
            Assert.That(checkBox.Checked, Is.True);
            checkBox.Checked = false;
            Assert.That(checkBox.Checked, Is.False);
        }
    }
}