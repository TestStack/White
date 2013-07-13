using System.Collections.Generic;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using Xunit;

namespace TestStack.White.UITests
{
    public class WindowTests : WhiteTestBase
    {
        public void GetAllWindows()
        {
            using (StartScenario("GetMultipleButton", "GetMultiple"))
            {
                Assert.Equal(2, Application.GetWindows().Count);
            }
        }

        public void FindWindow()
        {
            using (StartScenario("GetMultipleButton", "GetMultiple"))
            {
                Window foundWindow = Application.Find(obj => obj.StartsWith("GetMul"), InitializeOption.NoCache);
                Assert.NotNull(foundWindow);
            }
        }

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            RunTest(GetAllWindows);
            RunTest(FindWindow);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.WinForms;
            yield return WindowsFramework.Wpf;
        }
    }
}