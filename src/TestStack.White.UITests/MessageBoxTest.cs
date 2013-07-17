using System.Collections.Generic;
using TestStack.White.Configuration;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using Xunit;

namespace TestStack.White.UITests
{
    public class MessageBoxTest : WhiteTestBase
    {
        void CloseMessageBoxTest()
        {
            MainWindow.Get<Button>("OpenMessageBox").Click();
            Window messageBox = MainWindow.MessageBox("Test message box");
            var label = MainWindow.Get<Label>("65535");
            Assert.Equal("Close me", label.Text);
            messageBox.Close();
        }

        void ClickButtonOnMessageBox()
        {
            MainWindow.Get<Button>("OpenMessageBox").Click();
            Window messageBox = MainWindow.MessageBox("Test message box");
            messageBox.Get<Button>(SearchCriteria.ByText("OK")).Click();
        }

        void ThrowsWhenNotFound()
        {
            using (CoreAppXmlConfiguration.Instance.ApplyTemporarySetting(c => c.FindWindowTimeout = 500))
            {
                var exception = Assert.Throws<AutomationException>(() => MainWindow.MessageBox("foo"));

                Assert.Equal("Could not find modal window with title: foo", exception.Message);
            }
        }

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            RunTest(CloseMessageBoxTest);
            RunTest(ClickButtonOnMessageBox);
            RunTest(ThrowsWhenNotFound);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.WinForms;
            yield return WindowsFramework.Wpf;
        }
    }
}