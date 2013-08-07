using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Automation;
using TestStack.White.Configuration;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using Xunit;

namespace TestStack.White.UITests
{
    public class WindowTests : WhiteTestBase
    {
        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            RunTest(GetAllWindows);
            RunTest(FindWindow);
            RunTest(WindowWithoutTitleBar, WindowsFramework.WinForms);
            RunTest(WindowWithAmerstand, WindowsFramework.WinForms);
            RunTest(IsCurrentlyActive);
            RunTest(IsCurrentlyNotActive);
            RunTest(HasAttachedMouse);
            RunTest(FindNonExistentItem);
            RunTest(GetAll);
            RunTest(FindTabs);
            RunTest(FindControlsInsideAPanel);
            RunTest(SetWindowState);
            RunTest(HandleDynamicallyAddedControls);
            RunTest(GetTitle);
            RunTest(ItemsWithin);
            RunTest(WindowScrollsToMakeItemVisibleBeforePerformingAnyAction);
            RunTest(FindToolBarsWhenThereAreMultiple);
            RunTest(HandlesInvisibleControlsWinforms, WindowsFramework.WinForms);
            RunTest(HandlesInvisibleControlsWpf, WindowsFramework.Wpf);
            RunTest(IsClosed);
            RunTest(CanFindTitleBar);
        }

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

        void WindowWithAmerstand()
        {
            using (var window = StartScenario("OpenWindowWithAmperstand", "WindowWithAmperstand&1"))
                Assert.NotNull(window);
        }

        void IsCurrentlyActive()
        {
            MainWindow.Focus();
            Assert.True(MainWindow.IsCurrentlyActive);
            MainWindow.Get<Button>("ButtonWithTooltip").Click();
            Assert.True(MainWindow.IsCurrentlyActive);
        }

        void IsCurrentlyNotActive()
        {
            const string exeSourceFile = @"C:\Windows\system32\calc.exe";
            var psi = new ProcessStartInfo(exeSourceFile);
            // launch the process through white application
            using (var application = Application.AttachOrLaunch(psi))
            using (var mainWindow = application.GetWindow(SearchCriteria.ByText("Calculator"), InitializeOption.NoCache))
            {
                mainWindow.Focus();
                Assert.Equal(false, MainWindow.IsCurrentlyActive);
            }
        }

        void HandlesInvisibleControlsWinforms()
        {
            using (CoreAppXmlConfiguration.Instance.ApplyTemporarySetting(c => c.BusyTimeout = 100))
            {
                var exception = Assert.Throws<AutomationException>(() => MainWindow.Get<TextBox>("HiddenTextBox"));
                Assert.Equal("Failed to get (ControlType=edit or ControlType=document),AutomationId=HiddenTextBox",
                    exception.Message);
            }

            MainWindow.Get<Button>("ShowHiddenTextBox").Click();
            var textBox = MainWindow.Get<TextBox>("HiddenTextBox");
            Assert.True(textBox.Visible);
        }

        void HandlesInvisibleControlsWpf()
        {
            var textBox = MainWindow.Get<TextBox>("HiddenTextBox");
            Assert.False(textBox.Visible);
            MainWindow.Get<Button>("ShowHiddenTextBox").Click();
            Assert.True(textBox.Visible);
        }

        void FindToolBarsWhenThereAreMultiple()
        {
            Assert.NotEqual(null, MainWindow.GetToolStrip("ToolStrip1"));
            Assert.NotEqual(null, MainWindow.GetToolStrip("ToolStrip2"));
            using (CoreAppXmlConfiguration.Instance.ApplyTemporarySetting(c => c.BusyTimeout = 100))
            {
                var exception = Assert.Throws<AutomationException>(() => MainWindow.GetToolStrip("ToolStrip3"));
                Assert.Equal("Failed to get AutomationId=ToolStrip3", exception.Message);
            }
        }

        void WindowScrollsToMakeItemVisibleBeforePerformingAnyAction()
        {
            using (var window = StartScenario("OpenWindowWithScrollbars", "WindowWithScrollbars"))
            {
                var button = window.Get<Button>("HiddenButton");
                button.Click();
                Assert.Equal("HiddenButtonClicked", button.LegacyHelpText);
                var buttonUpTop = window.Get<Button>("ButtonBackUpTop");
                buttonUpTop.Click();
                Assert.Equal("ButtonBackUpTopClicked", buttonUpTop.LegacyHelpText);
            }
        }

        void ItemsWithin()
        {
            var groupBox = MainWindow.Get<GroupBox>("ScenariosPane");
            List<UIItem> uiItems = MainWindow.ItemsWithin(groupBox);
            Assert.True(uiItems.Count > 1, "Scenarios should have more than 1 button");
            Assert.True(uiItems.OfType<Button>().Count() > 1, "Scenarios should have more than 1 button");
        }

        void GetTitle()
        {
            Assert.NotNull(MainWindow.Title);
        }

        void HandleDynamicallyAddedControls()
        {
            SelectOtherControls();
            using (CoreAppXmlConfiguration.Instance.ApplyTemporarySetting(c => c.BusyTimeout = 100))
                Assert.Throws<AutomationException>(() => MainWindow.Get<TextBox>("AddedTextBox"));

            MainWindow.Get<Button>("AddTextBox").Click();
            Assert.NotEqual(null, MainWindow.Get<TextBox>("AddedTextBox"));
        }

        void SetWindowState()
        {
            try
            {
                MainWindow.DisplayState = DisplayState.Maximized;
                Assert.Equal(DisplayState.Maximized, MainWindow.DisplayState);

                MainWindow.DisplayState = DisplayState.Restored;
                Assert.Equal(DisplayState.Restored, MainWindow.DisplayState);

                MainWindow.DisplayState = DisplayState.Minimized;
                Assert.Equal(DisplayState.Minimized, MainWindow.DisplayState);
            }
            finally
            {
                MainWindow.DisplayState = DisplayState.Restored;                
            }
        }

        void FindControlsInsideAPanel()
        {
            SelectOtherControls();
            var textBox = MainWindow.Get<TextBox>("TextBoxInsidePanel");
            Assert.NotNull(textBox);
        }

        void FindTabs()
        {
            Assert.Equal(1, MainWindow.Tabs.Count);
        }

        void GetAll()
        {
            Assert.NotEmpty(MainWindow.Items);
        }

        void HasAttachedMouse()
        {
            Assert.NotNull(MainWindow.Mouse);
        }

        void FindNonExistentItem()
        {
            var excepion = Assert.Throws<AutomationException>(() => MainWindow.Get<TextBox>("DoesntExist"));
            Assert.Contains("Failed to get", excepion.Message);
            Assert.Contains("ControlType=edit", excepion.Message);
            Assert.Contains("AutomationId=DoesntExist", excepion.Message);
        }

        void IsClosed()
        {
            MainWindow.Get<Button>("GetMultipleButton").Click();
            var window = MainWindow.ModalWindow("GetMultiple");
            Assert.False(window.IsClosed);
            window.Close();
            window.WaitTill(() => window.IsClosed);
            Assert.True(window.IsClosed);
        }

        void CanFindTitleBar()
        {
            TitleBar titleBar = MainWindow.TitleBar;
            Assert.NotNull(titleBar.MinimizeButton);
            Assert.NotNull(titleBar.MaximizeButton);
            Assert.NotNull(titleBar.CloseButton);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.WinForms;
            yield return WindowsFramework.Wpf;
        }
    }
}