using System.Collections.Generic;
using TestStack.White.UIItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests
{
    public class ImageTest : WhiteTestBase
    {
        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            RunTest(Get);
        }

        void Get()
        {
            SelectOtherControls();
            var image = MainWindow.Get<Image>("Image");
            Assert.NotNull(image);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
        }
    }
}