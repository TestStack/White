using NUnit.Framework;
using TestStack.White.UIItems;

namespace TestStack.White.UITests.InputDevices
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class AttachedKeyboardTests : WhiteUITestBase
    {
        public AttachedKeyboardTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [Test]
        public void EnterTest()
        {
            SelectInputControls();
            var textBox = MainWindow.Get<TextBox>("TextBox");
            textBox.Focus();
            var attachedKeyboard = MainWindow.Keyboard;
            attachedKeyboard.Enter("a");
            Assert.That(textBox.Text, Is.EqualTo("a"));
        }
    }
}