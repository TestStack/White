using System.Collections.Generic;
using TestStack.White.UIItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests
{
    public class LabelTest : WhiteTestBase
    {
        void Text()
        {
            var label = MainWindow.Get<Label>("DateTimePickerLabel");
            Assert.NotEqual(null, label.Text);
        }

        void FindTextBlock()
        {
            var label = MainWindow.Get<Label>("PasswordTextBlock");
            Assert.NotEqual(null, label);
        }

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            RunTest(Text);
            RunTest(FindTextBlock, WindowsFramework.Wpf);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
        }
    }
}