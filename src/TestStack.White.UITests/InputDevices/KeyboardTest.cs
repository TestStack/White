using System.Collections.Generic;
using System.Text;
using White.Core.InputDevices;
using White.Core.UIItems;
using White.Core.WindowsAPI;
using Xunit;

namespace TestStack.White.UITests.InputDevices
{
    public class KeyboardTest : WhiteTestBase
    {
        private readonly TextBox textBox;

        public KeyboardTest()
        {
            textBox = MainWindow.Get<TextBox>("TextBox");
        }

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            RunTest(EnterAccentedChars);
            RunTest(ShouldSetTheValueOfATextBox);
            RunTest(ShouldBeAbleToPressLeftAndRightCursorKeys);
            RunTest(DoNotAllowToLeaveKeyWhichIsNotHeld);
            RunTest(CapsLock);
            RunTest(LeaveAllKeys);
            RunTest(LeaveKey);
            RunTest(MultilineTextBox);
        }

        void EnterAccentedChars()
        {
            const string text = "דאגהבדאגהבדאגהבדאגהבדאגהבדאגהבדאגהבדאגהב";

            textBox.BulkText = text;

            Assert.Equal(text, textBox.Text);
        }

        void ShouldSetTheValueOfATextBox()
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

        void ShouldBeAbleToPressLeftAndRightCursorKeys()
        {
            textBox.Text = "Textbox";

            Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.RIGHT, MainWindow);
            Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.BACKSPACE, MainWindow);
            Assert.Equal("Textbo", textBox.Text);

            Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.LEFT, MainWindow);
            Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.LEFT, MainWindow);
            Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.BACKSPACE, MainWindow);
            Assert.Equal("Texbo", textBox.Text);
        }

        void DoNotAllowToLeaveKeyWhichIsNotHeld()
        {
            Assert.Throws<InputDeviceException>(()=>Keyboard.Instance.LeaveKey(KeyboardInput.SpecialKeys.LEFT, MainWindow));
        }

        void CapsLock()
        {
            textBox.Focus();
            Keyboard.CapsLockOn = false;
            Keyboard.Enter("a");
            Assert.Equal("a", textBox.Text);
            Assert.Equal(false, Keyboard.CapsLockOn);

            Keyboard.CapsLockOn = true;
            Keyboard.Enter("a");
            Assert.Equal(true, Keyboard.CapsLockOn);
            Assert.Equal("aA", textBox.Text);

            Keyboard.CapsLockOn = false;
            Keyboard.Enter("a");
            Assert.Equal(false, Keyboard.CapsLockOn);
            Assert.Equal("aAa", textBox.Text);
        }

        void LeaveAllKeys()
        {
            Keyboard.HoldKey(KeyboardInput.SpecialKeys.ALT);
            Keyboard.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
            Assert.Equal(2, Keyboard.HeldKeys.Length);
            Keyboard.LeaveAllKeys();
            Assert.Equal(0, Keyboard.HeldKeys.Length);
        }

        void LeaveKey()
        {
            Keyboard.HoldKey(KeyboardInput.SpecialKeys.ALT);
            Assert.Equal(1, Keyboard.HeldKeys.Length);
            Keyboard.LeaveKey(KeyboardInput.SpecialKeys.ALT);
            Assert.Equal(0, Keyboard.HeldKeys.Length);
        }

        void MultilineTextBox()
        {
            var builder = new StringBuilder();
            builder.Append("abcd").AppendLine();
            builder.Append("efgh").AppendLine();
            var multilineTextBox = MainWindow.Get<MultilineTextBox>("MultilineTextBox");
            multilineTextBox.Text = builder.ToString();
            Assert.Equal(builder.ToString(), multilineTextBox.Text);
        }

        void EnterAndAssertValueOfTextEntered(string stringToType)
        {
            ClearTextBox();
            Keyboard.Send(stringToType, MainWindow);
            Assert.Equal(stringToType, textBox.Text);
            ClearTextBox();
        }

        void ClearTextBox()
        {
            textBox.Text = string.Empty;
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.WinForms;
            yield return WindowsFramework.Wpf;
        }

        public override void Dispose()
        {
            Keyboard.LeaveAllKeys();
            base.Dispose();
        }
    }
}