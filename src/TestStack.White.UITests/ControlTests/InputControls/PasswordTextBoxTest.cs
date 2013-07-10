using System;
using System.Collections.Generic;
using White.Core;
using White.Core.UIItems;
using White.Core.Utility;
using Xunit;

namespace TestStack.White.UITests.ControlTests.InputControls
{
    public class PasswordTextBoxTest : WhiteTestBase
    {
        public void CannotGetTextFromPassword()
        {
            var textBox = MainWindow.Get<TextBox>("PasswordBox");
            textBox.BulkText = "foobar";
            var exception = Assert.Throws<WhiteException>(() =>
            {
                // ReSharper disable once UnusedVariable
                var text = textBox.Text;
            });
            Assert.Equal("Text cannot be retrieved from textbox which has secret text (e.g. password) stored in it", exception.Message);
        }

        public void GetPasswordValueWhenTextBoxIsNotPasswordField()
        {
            var textBox = MainWindow.Get<TextBox>("PasswordBox");
            textBox.BulkText = "foobar";
            MainWindow.Get<Button>("UnmaskPasswordButton").Click();
            textBox = MainWindow.Get<TextBox>("PasswordBox");
            string text = Retry.For(() => textBox.Text, TimeSpan.FromSeconds(2));
            Assert.Equal("foobar", text);
        }

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            RunTest(CannotGetTextFromPassword);
            RunTest(GetPasswordValueWhenTextBoxIsNotPasswordField, WindowsFramework.WinForms);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.WinForms;
            yield return WindowsFramework.Wpf;
        }
    }
}