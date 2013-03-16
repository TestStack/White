using System.Collections.Generic;
using NUnit.Framework;
using White.Core.UIItems;

namespace TestStack.White.UITests.ControlTests
{
    public class TooltipTests : WhiteTestBase
    {
        protected override void RunTest(WindowsFramework framework)
        {
            RunTest(CanGetTooltip);
        }

        private void CanGetTooltip()
        {
            var button = MainWindow.Get<Button>("ButtonWithTooltip");
            Assert.AreEqual("I have a tooltip", MainWindow.GetToolTipOn(button).Text);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
        }
    }
}