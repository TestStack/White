using System;
using System.Collections.Generic;
using White.Core.UIItems;
using White.Core.Utility;
using White.Core.WindowsAPI;
using Xunit;

namespace TestStack.White.UITests.ControlTests
{
    public class HotKeyTest : WhiteTestBase
    {
        public void AccessKey(WindowsFramework framework)
        {
            var button = MainWindow.Get<Button>("ButtonWithTooltip");
            if (framework != WindowsFramework.Wpf) Assert.Equal("Alt+B", button.AccessKey);
            Keyboard.HoldKey(KeyboardInput.SpecialKeys.ALT);
            Keyboard.Enter("B");
            Keyboard.LeaveKey(KeyboardInput.SpecialKeys.ALT);
            Retry.For(()=>Assert.Equal("Clicked", button.Text), TimeSpan.FromSeconds(2));
        }

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            RunTest(()=>AccessKey(framework));
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.WinForms;
            yield return WindowsFramework.Wpf;
        }
    }
}