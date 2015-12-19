using NUnit.Framework;
using System.Windows.Automation;
using TestStack.White.UIItems;

namespace TestStack.White.UITests.ControlTests.InputControls
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class TristateItemTests : WhiteUITestBase
    {
        public TristateItemTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [OneTimeSetUp]
        public void Setup()
        {
            SelectInputControls();
        }

        [Test]
        public void TristateCheckboxTest()
        {
            SelectInputControls();
            var checkBox = MainWindow.Get<CheckBox>("TriStateCheckBox");
            Assert.That(checkBox.State, Is.EqualTo(ToggleState.Indeterminate));
            checkBox.State = ToggleState.On;
            Assert.That(checkBox.State, Is.EqualTo(ToggleState.On));
            checkBox.State = ToggleState.Off;
            Assert.That(checkBox.State, Is.EqualTo(ToggleState.Off));
        }
    }
}