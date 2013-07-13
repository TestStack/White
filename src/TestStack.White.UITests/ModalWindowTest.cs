using System.Collections.Generic;
using TestStack.White.Configuration;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using Xunit;

namespace TestStack.White.UITests
{
    public class ModalWindowTest : WhiteTestBase
    {
        void GetModalWindow()
        {
            LaunchModalWindow();
            Window modalWindow = MainWindow.ModalWindow("GetMultiple");
            Assert.NotNull(modalWindow);
            modalWindow.Close();
        }

        void GetModalWindowBasedOnSearchCriteria()
        {
            LaunchModalWindow();
            Window modalWindow = MainWindow.ModalWindow(SearchCriteria.ByText("GetMultiple"));
            Assert.NotNull(modalWindow);
            modalWindow.Close();
        }

        void GetControlFromModalWindowWhenSessionActive()
        {
            LaunchModalWindow();
            Window modalWindow = MainWindow.ModalWindow("GetMultiple", InitializeOption.NoCache.AndIdentifiedBy("ModalForm"));
            Assert.NotNull(modalWindow);
            modalWindow.Close();
        }

        void ThrowsWhenNotFound()
        {
            using (CoreAppXmlConfiguration.Instance.ApplyTemporarySetting(s => s.FindWindowTimeout = 1000))
            {
                var exception = Assert.Throws<AutomationException>(() => MainWindow.ModalWindow("foo"));
                Assert.Equal("Could not find modal window with title: foo", exception.Message);
            }
        }

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            RunTest(GetModalWindow);
            RunTest(GetModalWindowBasedOnSearchCriteria);
            RunTest(GetControlFromModalWindowWhenSessionActive);
            RunTest(ThrowsWhenNotFound);
        }

        void LaunchModalWindow()
        {
            MainWindow.Get<Button>("GetMultipleButton").Click();
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
        }
    }
}