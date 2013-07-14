using System.Collections.Generic;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using Xunit;

namespace TestStack.White.UITests.InputDevices
{
    public class AttachedKeyboardTest : WhiteTestBase
    {
        public void Enter()
        {
            SelectInputControls();
            var textBox = MainWindow.Get<TextBox>("TextBox");
            textBox.Focus();
            AttachedKeyboard attachedKeyboard = MainWindow.Keyboard;
            attachedKeyboard.Enter("a");
            Assert.Equal("a", textBox.Text);
        }

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            RunTest(Enter);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.WinForms;
            yield return WindowsFramework.Wpf;
        }
    }
}