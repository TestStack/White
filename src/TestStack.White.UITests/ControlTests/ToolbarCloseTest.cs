using System.Collections.Generic;
using NUnit.Framework;
using White.Core.UIItems;

namespace TestStack.White.UITests.ControlTests
{
    public class ToolbarCloseTest : WhiteTestBase
    {
        protected override void RunTest(WindowsFramework framework)
        {
            RunTest(ClickTitleBarClose);
        }

        private void ClickTitleBarClose()
        {
            MainWindow.TitleBar.CloseButton.Click();
            Assert.True(Application.HasExited);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.WinForms;
        }
    }
}
