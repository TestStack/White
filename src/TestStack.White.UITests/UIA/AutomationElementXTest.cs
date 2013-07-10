using System.Collections.Generic;
using White.Core.UIA;
using White.Core.UIItems;
using Xunit;

namespace TestStack.White.UITests.UIA
{
    public class AutomationElementXTest : WhiteTestBase
    {
        public void TestToString(string frameworkid)
        {
            var button = MainWindow.Get<Button>("ButtonWithTooltip");
            string s = button.AutomationElement.Display();
            Assert.Equal(string.Format("AutomationId:ButtonWithTooltip, Name:Button with Tooltip, ControlType:button, FrameworkId:{0}", frameworkid), s);
        }

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            RunTest(()=>TestToString(framework.FrameworkId));
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.WinForms;
            yield return WindowsFramework.Wpf;
        }
    }
}