using System.Text;
using NUnit.Framework;
using White.Core.InputDevices;
using White.Core.UIItems;
using White.Core.UITests.Testing;
using White.Core.WindowsAPI;

namespace White.Core.UITests.InputDevices
{
    [TestFixture, NormalCategory]
    public class KeyboardTest : ControlsActionTest
    {
        private TextBox textBox;

        protected override void TestFixtureSetUp()
        {
            textBox = window.Get<TextBox>("textBox");
        }

        [TearDown]
        public void TearDown()
        {
            Keyboard.LeaveAllKeys();
        }

        [Test]
        public void EnterAccentedChars()
        {
            textBox.BulkText = "דאגהבדאגהבדאגהבדאגהבדאגהבדאגהבדאגהבדאגהב";
        }

        [Test]
        public void ShouldSetTheValueOfATextBox()
        {
            EnterAndAssertValueOfTextEntered("ab");
            EnterAndAssertValueOfTextEntered("abcdefghijklmnopqrstuvwxyz");
            EnterAndAssertValueOfTextEntered("0123456789");
            EnterAndAssertValueOfTextEntered("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            EnterAndAssertValueOfTextEntered("AaBbCcDdEeFfGHIJklmnOPqrSTUVwxyz");
            EnterAndAssertValueOfTextEntered("`[];',./-");
            EnterAndAssertValueOfTextEntered("~{}:\"<>?_");
            EnterAndAssertValueOfTextEntered("!@#$%^&*()");
        }

        [Test]
        public void ShouldBeAbleToPressLeftAndRightCursorKeys()
        {
            textBox.Text = "Textbox";

            Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.RIGHT, window);
            Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.BACKSPACE, window);
            Assert.AreEqual("Textbo", textBox.Text);

            Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.LEFT, window);
            Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.LEFT, window);
            Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.BACKSPACE, window);
            Assert.AreEqual("Texbo", textBox.Text);
        }

        [Test, ExpectedException(typeof (InputDeviceException))]
        public void DonotAllowToLeaveKeyWhichIsNotHeld()
        {
            Keyboard.Instance.LeaveKey(KeyboardInput.SpecialKeys.LEFT, window);
        }

        [Test]
        public void CapsLock()
        {
            Keyboard.CapsLockOn = false;
            Assert.AreEqual(false, Keyboard.CapsLockOn);
            Keyboard.CapsLockOn = true;
            Assert.AreEqual(true, Keyboard.CapsLockOn);
            Keyboard.CapsLockOn = false;
            Assert.AreEqual(false, Keyboard.CapsLockOn);
        }

        private void EnterAndAssertValueOfTextEntered(string stringToType)
        {
            ClearTextBox();
            Keyboard.Send(stringToType, window);
            Assert.AreEqual(stringToType, textBox.Text);
            ClearTextBox();
        }

        private void ClearTextBox()
        {
            textBox.Text = string.Empty;
        }

        [Test]
        public void LeaveAllKeys()
        {
            Keyboard.HoldKey(KeyboardInput.SpecialKeys.ALT);
            Keyboard.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
            Assert.AreEqual(2, Keyboard.HeldKeys.Length);
            Keyboard.LeaveAllKeys();
            Assert.AreEqual(0, Keyboard.HeldKeys.Length);
        }

        [Test]
        public void LeaveKey()
        {
            Keyboard.HoldKey(KeyboardInput.SpecialKeys.ALT);
            Assert.AreEqual(1, Keyboard.HeldKeys.Length);
            Keyboard.LeaveKey(KeyboardInput.SpecialKeys.ALT);
            Assert.AreEqual(0, Keyboard.HeldKeys.Length);
        }
    }

    [TestFixture, WinFormCategory]
    public class KeyboardTestOnWinForm : ControlsActionTest
    {
        [Test]
        public void MultilineTextBox()
        {
            var builder = new StringBuilder();
            builder.Append("abcd").AppendLine();
            builder.Append("efgh").AppendLine();
            var multilineTextBox = window.Get<MultilineTextBox>("multilineTextBox");
            multilineTextBox.Text = builder.ToString();
            Assert.AreEqual(builder.ToString(), multilineTextBox.Text);
        }
    }
}