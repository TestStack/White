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
            keyboard.LeaveAllKeys();
        }

        [Test, Ignore]
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

            keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.RIGHT, window);
            keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.BACKSPACE, window);
            Assert.AreEqual("Textbo", textBox.Text);

            keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.LEFT, window);
            keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.LEFT, window);
            keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.BACKSPACE, window);
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
            keyboard.CapsLockOn = false;
            Assert.AreEqual(false, keyboard.CapsLockOn);
            keyboard.CapsLockOn = true;
            Assert.AreEqual(true, keyboard.CapsLockOn);
            keyboard.CapsLockOn = false;
            Assert.AreEqual(false, keyboard.CapsLockOn);
        }

        private void EnterAndAssertValueOfTextEntered(string stringToType)
        {
            ClearTextBox();
            keyboard.Send(stringToType, window);
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
            keyboard.HoldKey(KeyboardInput.SpecialKeys.ALT);
            keyboard.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
            Assert.AreEqual(2, keyboard.HeldKeys.Length);
            keyboard.LeaveAllKeys();
            Assert.AreEqual(0, keyboard.HeldKeys.Length);
        }

        [Test]
        public void LeaveKey()
        {
            keyboard.HoldKey(KeyboardInput.SpecialKeys.ALT);
            Assert.AreEqual(1, keyboard.HeldKeys.Length);
            keyboard.LeaveKey(KeyboardInput.SpecialKeys.ALT);
            Assert.AreEqual(0, keyboard.HeldKeys.Length);
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