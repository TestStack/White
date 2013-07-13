using System.Collections.Generic;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using Xunit;

namespace TestStack.White.UITests
{
    public class WindowTests : WhiteTestBase
    {
        void GetAllWindows()
        {
            using (StartScenario("GetMultipleButton", "GetMultiple"))
            {
                Assert.Equal(2, Application.GetWindows().Count);
            }
        }

        void FindWindow()
        {
            using (StartScenario("GetMultipleButton", "GetMultiple"))
            {
                Window foundWindow = Application.Find(obj => obj.StartsWith("GetMul"), InitializeOption.NoCache);
                Assert.NotNull(foundWindow);
            }
        }

        void WindowWithoutTitleBar()
        {
            using (var window = StartScenario("OpenWindowWithNoTitleBar", "WindowWithNoTitleBar"))
            {
                Assert.NotNull(window);
            }
        }

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            RunTest(GetAllWindows);
            RunTest(FindWindow);
            RunTest(WindowWithoutTitleBar, WindowsFramework.WinForms);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.WinForms;
            yield return WindowsFramework.Wpf;
        }
    }
}