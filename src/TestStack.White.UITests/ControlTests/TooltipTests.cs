using System.Collections.Generic;
using TestStack.White.UIItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests
{
    public class TooltipTests : WhiteTestBase
    {
        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            RunTest(CanGetTooltip);
        }

        private void CanGetTooltip()
        {
            var button = MainWindow.Get<Button>("ButtonWithTooltip");
            Assert.Equal("I have a tooltip", MainWindow.GetToolTipOn(button).Text);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
        }
    }
}