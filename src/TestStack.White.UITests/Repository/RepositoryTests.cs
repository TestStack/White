using System.Collections.Generic;
using TestStack.White.UIItems;

namespace TestStack.White.UITests.Repository
{
    public class RepositoryTests : WhiteTestBase
    {
        protected override void ExecuteTestRun(WindowsFramework framework)
        {

        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
        }
    }
}