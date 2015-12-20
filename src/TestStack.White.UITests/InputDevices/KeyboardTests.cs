using NUnit.Framework;
using System;
using System.Text;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.WindowsAPI;

namespace TestStack.White.UITests.InputDevices
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class KeyboardTests : WhiteUITestBase
    {
        public KeyboardTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            Keyboard.LeaveAllKeys();
        }

        [Test]
        public void EnterAccentedCharsTest()
        {
            SelectInputControls();
            var textBox = MainWindow.Get<TextBox>("TextBox");
            const string text = "ãàâäáãàâäáãàâäáãàâäáãàâäáãàâäáãàâäáãàâäá";

            textBox.BulkText = text;

            Assert.That(textBox.Text, Is.EqualTo(text));
        }

        [Test]
        public void EnterUnicodeCharactersTest()
        {
            SelectInputControls();
            var textBox = MainWindow.Get<TextBox>("TextBox");
            const string text = "ŕ&aacute;&acirc;ă&auml;ĺć&ccedil;č&eacute;ę&euml;ě&iacute;&icirc;ď";

            textBox.BulkText = text;

            Assert.That(textBox.Text, Is.EqualTo(text));
        }

        [Test]
        public void ShouldSetTheValueOfATextBoxTest()
        {
            SelectInputControls();
            var textBox = MainWindow.Get<TextBox>("TextBox");
            EnterAndAssertValueOfTextEntered(textBox, "ab");
            EnterAndAssertValueOfTextEntered(textBox, "abcdefghijklmnopqrstuvwxyz");
            EnterAndAssertValueOfTextEntered(textBox, "0123456789");
            EnterAndAssertValueOfTextEntered(textBox, "ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            EnterAndAssertValueOfTextEntered(textBox, "AaBbCcDdEeFfGHIJklmnOPqrSTUVwxyz");
            EnterAndAssertValueOfTextEntered(textBox, "`[];',./-");
            EnterAndAssertValueOfTextEntered(textBox, "~{}:\"<>?_");
            EnterAndAssertValueOfTextEntered(textBox, "!@#$%^&*()");
        }

        [Test]
        public void ShouldBeAbleToPressLeftAndRightCursorKeysTest()
        {
            SelectInputControls();
            var textBox = MainWindow.Get<TextBox>("TextBox");
            textBox.Text = "Textbox";

            Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.RIGHT, MainWindow);
            Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.BACKSPACE, MainWindow);
            Assert.That(textBox.Text, Is.EqualTo("Textbo"));

            Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.LEFT, MainWindow);
            Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.LEFT, MainWindow);
            Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.BACKSPACE, MainWindow);
            Assert.That(textBox.Text, Is.EqualTo("Texbo"));
        }

        [Test]
        public void DoNotAllowToLeaveKeyWhichIsNotHeldTest()
        {
            Assert.That(() => { Keyboard.Instance.LeaveKey(KeyboardInput.SpecialKeys.LEFT, MainWindow); }, Throws.TypeOf<InputDeviceException>());
        }

        [Test]
        public void CapsLockTest()
        {
            SelectInputControls();
            var textBox = MainWindow.Get<TextBox>("TextBox");
            ClearTextBox(textBox);
            Keyboard.CapsLockOn = false;
            Assert.That(Keyboard.CapsLockOn, Is.False);
            Keyboard.CapsLockOn = true;
            Assert.That(Keyboard.CapsLockOn, Is.True);
            Keyboard.CapsLockOn = false;
            Assert.That(Keyboard.CapsLockOn, Is.False);
        }

        [Test]
        public void LeaveAllKeysTest()
        {
            Keyboard.HoldKey(KeyboardInput.SpecialKeys.ALT);
            Keyboard.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
            Assert.That(Keyboard.HeldKeys, Has.Length.EqualTo(2));
            Keyboard.LeaveAllKeys();
            Assert.That(Keyboard.HeldKeys, Has.Length.EqualTo(0));
        }

        [Test]
        public void LeaveKeyTest()
        {
            Keyboard.HoldKey(KeyboardInput.SpecialKeys.ALT);
            Assert.That(Keyboard.HeldKeys, Has.Length.EqualTo(1));
            Keyboard.LeaveKey(KeyboardInput.SpecialKeys.ALT);
            Assert.That(Keyboard.HeldKeys, Has.Length.EqualTo(0));
        }

        [Test]
        public void MultilineTextBoxTest()
        {
            SelectInputControls();
            var builder = new StringBuilder();
            builder.Append("abcd").AppendLine();
            builder.Append("efgh").AppendLine();
            var multilineTextBox = MainWindow.Get<TextBox>("MultiLineTextBox");
            multilineTextBox.Text = builder.ToString();
            Assert.That(multilineTextBox.Text, Is.EqualTo(builder.ToString()));
        }

        private void EnterAndAssertValueOfTextEntered(TextBox textBox, string stringToType)
        {
            ClearTextBox(textBox);
            Keyboard.Send(stringToType, MainWindow);
            Assert.That(textBox.Text, Is.EqualTo(stringToType));
            ClearTextBox(textBox);
        }

        private void ClearTextBox(TextBox textBox)
        {
            textBox.Text = String.Empty;
        }
    }
}