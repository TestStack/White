using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Automation;
using TestStack.White.Configuration;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace TestStack.White.UITests
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class WindowTests : WhiteUITestBase
    {
        public WindowTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [Test]
        public void GetAllWindowsTest()
        {
            using (StartScenario("GetMultipleButton", "GetMultiple"))
            {
                Assert.That(Application.GetWindows(), Has.Count.EqualTo(2));
            }
        }

        [Test]
        public void FindWindowTest()
        {
            using (StartScenario("GetMultipleButton", "GetMultiple"))
            {
                var foundWindow = Application.Find(obj => obj.StartsWith("GetMul"), InitializeOption.NoCache);
                Assert.That(foundWindow, Is.Not.Null);
            }
        }

        [Test]
        public void WindowWithoutTitleBarTest()
        {
            if (Framework != WindowsFramework.WinForms)
            {
                Assert.Ignore();
            }
            using (var window = StartScenario("OpenWindowWithNoTitleBar", "WindowWithNoTitleBar"))
            {
                Assert.That(window, Is.Not.Null);
            }
        }

        [Test]
        public void WindowWithAmerstandTest()
        {
            if (Framework != WindowsFramework.WinForms)
            {
                Assert.Ignore();
            }
            using (var window = StartScenario("OpenWindowWithAmperstand", "WindowWithAmperstand&1"))
            {
                Assert.That(window, Is.Not.Null);
            }
        }

        [Test]
        public void IsCurrentlyActiveTest()
        {
            MainWindow.Focus();
            Assert.That(MainWindow.IsCurrentlyActive, Is.True);
            MainWindow.Get<Button>("ButtonWithTooltip").Click();
            Assert.That(MainWindow.IsCurrentlyActive, Is.True);
        }

        [Test]
        public void IsCurrentlyNotActiveTest()
        {
            const string exeSourceFile = @"C:\Windows\system32\calc.exe";
            var psi = new ProcessStartInfo(exeSourceFile);
            // launch the process through white application
            using (var application = Application.AttachOrLaunch(psi))
            using (var mainWindow = application.GetWindow(SearchCriteria.ByText("Calculator"), InitializeOption.NoCache))
            {
                mainWindow.Focus();
                Assert.That(MainWindow.IsCurrentlyActive, Is.False);
            }
        }

        [Test]
        public void HandlesInvisibleControlsWinformsTest()
        {
            if (Framework != WindowsFramework.WinForms)
            {
                Assert.Ignore();
            }
            using (CoreConfigurationLocator.Get().ApplyTemporarySettings(c => c.BusyTimeout = 100))
            {
                Assert.That(() => { MainWindow.Get<TextBox>("HiddenTextBox"); },
                    Throws.TypeOf<AutomationException>().With.Message.EqualTo(
                        String.Format("Failed to get (ControlType={0} or ControlType={1}),AutomationId=HiddenTextBox",
                            ControlType.Edit.LocalizedControlType, ControlType.Document.LocalizedControlType)));
            }

            MainWindow.Get<Button>("ShowHiddenTextBox").Click();
            var textBox = MainWindow.Get<TextBox>("HiddenTextBox");
            Assert.That(textBox.Visible, Is.True);
        }

        [Test]
        public void HandlesInvisibleControlsWpfTest()
        {
            if (Framework != WindowsFramework.Wpf)
            {
                Assert.Ignore();
            }
            var textBox = MainWindow.Get<TextBox>("HiddenTextBox");
            Assert.That(textBox.Visible, Is.False);
            MainWindow.Get<Button>("ShowHiddenTextBox").Click();
            Assert.That(textBox.Visible, Is.True);
        }

        [Test]
        public void FindToolBarsWhenThereAreMultipleTest()
        {
            Assert.That(MainWindow.GetToolStrip("ToolStrip1"), Is.Not.Null);
            Assert.That(MainWindow.GetToolStrip("ToolStrip2"), Is.Not.Null);
            using (CoreConfigurationLocator.Get().ApplyTemporarySettings(c => c.BusyTimeout = 100))
            {
                Assert.That(() => { MainWindow.GetToolStrip("ToolStrip3"); },
                    Throws.TypeOf<AutomationException>().With.Message.EqualTo(
                        "Failed to get AutomationId=ToolStrip3"));
            }
        }

        [Test]
        [Category("NeedsFix")]
        [Ignore("NeedsFix")]
        public void WindowScrollsToMakeItemVisibleBeforePerformingAnyActionTest()
        {
            using (var window = StartScenario("OpenWindowWithScrollbars", "WindowWithScrollbars"))
            {
                var button = window.Get<Button>("HiddenButton");
                button.Click();
                Assert.That(button.HelpText, Is.EqualTo("HiddenButtonClicked"));
                var buttonUpTop = window.Get<Button>("ButtonBackUpTop");
                buttonUpTop.Click();
                Assert.That(buttonUpTop.HelpText, Is.EqualTo("ButtonBackUpTopClicked"));
            }
        }

        [Test]
        public void ItemsWithinTest()
        {
            var groupBox = MainWindow.Get<GroupBox>("ScenariosPane");
            var uiItems = MainWindow.ItemsWithin(groupBox);
            Assert.That(uiItems, Has.Count.GreaterThan(1), "Scenarios should have more than 1 button");
            Assert.That(uiItems.OfType<Button>().ToList(), Has.Count.GreaterThan(1), "Scenarios should have more than 1 button");
        }

        [Test]
        public void GetTitleTest()
        {
            Assert.That(MainWindow.Title, Is.Not.Null);
        }

        [Test]
        public void HandleDynamicallyAddedControlsTest()
        {
            SelectOtherControls();
            using (CoreConfigurationLocator.Get().ApplyTemporarySettings(c => c.BusyTimeout = 100))
            {
                Assert.That(() => { MainWindow.Get<TextBox>("AddedTextBox"); },
                    Throws.TypeOf<AutomationException>());
            }

            MainWindow.Get<Button>("AddTextBox").Click();
            Assert.That(MainWindow.Get<TextBox>("AddedTextBox"), Is.Not.Null);
        }

        [Test]
        public void SetWindowStateTest()
        {
            try
            {
                MainWindow.DisplayState = DisplayState.Maximized;
                Assert.That(MainWindow.DisplayState, Is.EqualTo(DisplayState.Maximized));

                MainWindow.DisplayState = DisplayState.Restored;
                Assert.That(MainWindow.DisplayState, Is.EqualTo(DisplayState.Restored));

                MainWindow.DisplayState = DisplayState.Minimized;
                Assert.That(MainWindow.DisplayState, Is.EqualTo(DisplayState.Minimized));
            }
            finally
            {
                MainWindow.DisplayState = DisplayState.Restored;
            }
        }

        [Test]
        public void FindControlsInsideAPanelTest()
        {
            SelectOtherControls();
            var textBox = MainWindow.Get<TextBox>("TextBoxInsidePanel");
            Assert.That(textBox, Is.Not.Null);
        }

        [Test]
        public void FindTabsTest()
        {
            Assert.That(MainWindow.Tabs, Has.Count.EqualTo(1));
        }

        [Test]
        public void GetAllTest()
        {
            Assert.That(MainWindow.Items, Is.Not.Empty);
        }

        [Test]
        public void HasAttachedMouseTest()
        {
            Assert.That(MainWindow.Mouse, Is.Not.Null);
        }

        [Test]
        public void FindNonExistentItemTest()
        {
            Assert.That(() => { MainWindow.Get<TextBox>("DoesntExist"); },
                Throws.TypeOf<AutomationException>().
                    With.Message.Contains("Failed to get").
                    And.Message.Contains(String.Format("ControlType={0}", ControlType.Edit.LocalizedControlType)).
                    And.Message.Contains("AutomationId=DoesntExist"));
        }

        [Test]
        public void IsClosedTest()
        {
            MainWindow.Get<Button>("GetMultipleButton").Click();
            var window = MainWindow.ModalWindow("GetMultiple");
            Assert.That(window.IsClosed, Is.False);
            window.Close();
            window.WaitTill(() => window.IsClosed);
            Assert.That(window.IsClosed, Is.True);
        }

        [Test]
        public void CanFindTitleBarTest()
        {
            var titleBar = MainWindow.TitleBar;
            Assert.That(titleBar.MinimizeButton, Is.Not.Null);
            Assert.That(titleBar.MaximizeButton, Is.Not.Null);
            Assert.That(titleBar.CloseButton, Is.Not.Null);
        }
    }
}