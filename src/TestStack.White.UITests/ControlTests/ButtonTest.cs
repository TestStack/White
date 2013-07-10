using System.Collections.Generic;
using White.Core;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using Xunit;

namespace TestStack.White.UITests.ControlTests
{
    public class ButtonTest : WhiteTestBase
    {
        public void Click()
        {
            var button = MainWindow.Get<Button>("ButtonWithTooltip");
            button.Click();
            
            Assert.Equal(button.Text, "Button Clicked with Mouse");
        }

        public void ThrowsWhenNotFound()
        {
            var exception = Assert.Throws<AutomationException>(()=>MainWindow.Get<Button>(SearchCriteria.ByAutomationId("foo")));

            Assert.Equal("Failed to get ControlType=button,AutomationId=foo", exception.Message);
        }

        public void RaiseClickEvent()
        {
            var button = MainWindow.Get<Button>("ButtonWithTooltip");
            button.RaiseClickEvent();
            Assert.Equal(button.Text, "Clicked");
        }

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            RunTest(RaiseClickEvent);
            RunTest(Click);
            RunTest(ThrowsWhenNotFound);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
        }
    }
}