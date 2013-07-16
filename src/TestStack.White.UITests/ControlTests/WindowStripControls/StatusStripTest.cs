using System.Collections.Generic;
using TestStack.White.Configuration;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowStripControls;
using Xunit;

namespace TestStack.White.UITests.ControlTests.WindowStripControls
{
    public class StatusStripTest : WhiteTestBase
    {
        StatusStrip statusStrip;

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            SelectOtherControls();
            statusStrip = MainWindow.StatusBar(InitializeOption.NoCache);

            RunTest(Find);
            RunTest(ThrowsWhenDoesNotExists);
            RunTest(FindLabelInsideStatusBar);
            RunTest(ClickOnButtonAndFindPopupMenu);
            RunTest(FindDropDown);
            RunTest(ProgressBar);
            RunTest(ProgressBar2);
        }

        void Find()
        {
            Assert.NotNull(statusStrip);
        }

        void ThrowsWhenDoesNotExists()
        {
            using (CoreAppXmlConfiguration.Instance.ApplyTemporarySetting(c => c.BusyTimeout = 100))
            {
                var exception = Assert.Throws<AutomationException>(() => MainWindow.Get<StatusStrip>("foo"));

                Assert.Equal("Failed to get ControlType=status bar,AutomationId=foo", exception.Message);
            }
        }

        void FindLabelInsideStatusBar()
        {
            UIItem uiItem = statusStrip.GetLabel("Status Strip Label");
            Assert.NotNull(uiItem);
        }

        void ClickOnButtonAndFindPopupMenu()
        {
            StatusStripSplitButton statusStripSplitButton = statusStrip.GetSplitButton("toolStripSplitButtonText");
            Assert.NotNull(statusStripSplitButton);
            statusStripSplitButton.Click();
        }

        void FindDropDown()
        {
            StatusStripDropDownButton button = statusStrip.GetDropDownButton("toolStripDropDownButton");
            Assert.NotNull(button);
            button.Click();
        }

        void ProgressBar()
        {
            ProgressBar progressBar = statusStrip.GetProgressBar();
            Assert.Equal(0, progressBar.Minimum);
            Assert.Equal(33, progressBar.Value);
            Assert.Equal(100, progressBar.Maximum);
        }

        void ProgressBar2()
        {
            ProgressBar progressBar = statusStrip.GetProgressBar(1);
            Assert.Equal(0, progressBar.Minimum);
            Assert.Equal(67, progressBar.Value);
            Assert.Equal(100, progressBar.Maximum);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.WinForms;
        }
    }
}