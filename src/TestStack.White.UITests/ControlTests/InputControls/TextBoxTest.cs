using System;
using System.Collections.Generic;
using System.Windows;
using White.Core.InputDevices;
using White.Core.UIItems;
using White.Core.Utility;
using White.Core.WindowsAPI;
using Xunit;

namespace TestStack.White.UITests.ControlTests.InputControls
{
    public class TextBoxTest : WhiteTestBase
    {
        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            RunTest(IsReadOnly);
            RunTest(CopyTest);
            RunTest(EnterText);
            RunTest(EnterBulkText);
        }

        public void EnterText()
        {
            var textBox = MainWindow.Get<TextBox>("TextBox");
            textBox.Text = "somethingElse";
            Assert.Equal("somethingElse", textBox.Text);
            Assert.Equal("Text Changed", textBox.HelpText);
            textBox.Text = "";
            Assert.Equal("", textBox.Text);
            textBox.Text = "againSomethingElse";
            Assert.Equal("againSomethingElse", textBox.Text);
        }

        public void EnterBulkText()
        {
            var textBox = MainWindow.Get<TextBox>("TextBox");
            textBox.BulkText = "somethingElse";
            Assert.Equal("somethingElse", textBox.Text);
        }

        public void CopyTest()
        {
            var textBox = MainWindow.Get<TextBox>("TextBox");
            AttachedKeyboard attachedKeyboard = MainWindow.Keyboard;
            textBox.Text = "userText";
            attachedKeyboard.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
            attachedKeyboard.Enter("ac");
            attachedKeyboard.LeaveKey(KeyboardInput.SpecialKeys.CONTROL);


            //check the text is the same as that on the clipboard
            Retry.For(() =>
            {
                string clipbrdText = Clipboard.GetText();
                Assert.Equal(textBox.Text, clipbrdText);
            }, TimeSpan.FromSeconds(5));
        }

        void IsReadOnly()
        {
            var textBox = MainWindow.Get<TextBox>("TextBox");
            Assert.Equal(false, textBox.IsReadOnly);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.WinForms;
            yield return WindowsFramework.Wpf;
        }
    }
}