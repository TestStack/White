﻿using System.Collections.Generic;
using System.Text;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.WindowsAPI;
using Xunit;

namespace TestStack.White.UITests.InputDevices
{
    public class KeyboardTest : WhiteTestBase
    {
        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            RunTest(EnterAccentedChars);
            RunTest(EnterUnicodeCharacters);
            RunTest(MultilineTextBox);
            RunTest(ShouldSetTheValueOfATextBox);
            RunTest(ShouldBeAbleToPressLeftAndRightCursorKeys);
            RunTest(DoNotAllowToLeaveKeyWhichIsNotHeld);
            RunTest(CapsLock);
            RunTest(LeaveAllKeys);
            RunTest(LeaveKey);
        }

        void EnterAccentedChars()
        {
            SelectInputControls();
            var textBox = MainWindow.Get<TextBox>("TextBox");
            const string text = "ãàâäáãàâäáãàâäáãàâäáãàâäáãàâäáãàâäáãàâäá";

            textBox.BulkText = text;

            Assert.Equal(text, textBox.Text);
        }

        void EnterUnicodeCharacters()
        {
            SelectInputControls();
            var textBox = MainWindow.Get<TextBox>("TextBox");
            const string text = "ŕ&aacute;&acirc;ă&auml;ĺć&ccedil;č&eacute;ę&euml;ě&iacute;&icirc;ď";

            textBox.BulkText = text;

            Assert.Equal(text, textBox.Text);
        }

        void ShouldSetTheValueOfATextBox()
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

        void ShouldBeAbleToPressLeftAndRightCursorKeys()
        {
            SelectInputControls();
            var textBox = MainWindow.Get<TextBox>("TextBox");
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
            SelectInputControls();
            var textBox = MainWindow.Get<TextBox>("TextBox");
            ClearTextBox(textBox);
            Keyboard.CapsLockOn = false;
            Assert.Equal(false, Keyboard.CapsLockOn);
            Keyboard.CapsLockOn = true;
            Assert.Equal(true, Keyboard.CapsLockOn);
            Keyboard.CapsLockOn = false;
            Assert.Equal(false, Keyboard.CapsLockOn);
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
            SelectInputControls();
            var builder = new StringBuilder();
            builder.Append("abcd").AppendLine();
            builder.Append("efgh").AppendLine();
            var multilineTextBox = MainWindow.Get<TextBox>("MultiLineTextBox");
            multilineTextBox.Text = builder.ToString();
            Assert.Equal(builder.ToString(), multilineTextBox.Text);
        }

        void EnterAndAssertValueOfTextEntered(TextBox textBox, string stringToType)
        {
            ClearTextBox(textBox);
            Keyboard.Send(stringToType, MainWindow);
            Assert.Equal(stringToType, textBox.Text);
            ClearTextBox(textBox);
        }

        void ClearTextBox(TextBox textBox)
        {
            textBox.Text = string.Empty;
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.WinForms;
            yield return WindowsFramework.Wpf;
        }

        public void Dispose()
        {
            Keyboard.LeaveAllKeys();
        }
    }
}