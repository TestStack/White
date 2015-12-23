using NUnit.Framework;
using TestStack.White.UIItems;

namespace TestStack.White.UITests.ControlTests.InputControls
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class RadioButtonTests : WhiteUITestBase
    {
        public RadioButtonTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [OneTimeSetUp]
        public void Setup()
        {
            SelectInputControls();
        }

        [Test]
        public void SelectSingleRadioButtonTest()
        {
            var radioButton = MainWindow.Get<RadioButton>("RadioButton1");
            Assert.That(radioButton.IsSelected, Is.False);
            radioButton.Select();
            Assert.That(radioButton.IsSelected, Is.True);
        }

        [Test]
        public void SelectRadioButtonGroupTest()
        {
            var radioButton1 = MainWindow.Get<RadioButton>("RadioButton1");
            var radioButton2 = MainWindow.Get<RadioButton>("RadioButton2");

            Assert.That(radioButton1.IsSelected && radioButton2.IsSelected, Is.False);

            radioButton1.Select();
            Assert.That(radioButton1.IsSelected, Is.True);
            Assert.That(radioButton2.IsSelected, Is.False);

            radioButton2.Select();

            Assert.That(radioButton1.IsSelected, Is.False);
            // ReSharper disable once HeuristicUnreachableCode
            Assert.That(radioButton2.IsSelected, Is.True);
        }
    }
}