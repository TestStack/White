using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using Castle.Core.Logging;
using TestStack.White.Configuration;
using TestStack.White.InputDevices;
using TestStack.White.ScreenObjects;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UITests.Infrastructure;
using TestStack.White.UITests.Screens;
using Xunit;

namespace TestStack.White.UITests
{
    public abstract class WhiteTestBase
    {
        readonly ILogger logger = CoreAppXmlConfiguration.Instance.LoggerFactory.Create(typeof(WhiteTestBase));
        readonly List<Window> windowsToClose = new List<Window>();
        readonly string screenshotDir;
        WindowsFramework? currentFramework;

        internal Keyboard Keyboard;

        protected WhiteTestBase()
        {
            screenshotDir = "c:\\FailedTestsScreenshots";
            if (!Directory.Exists(screenshotDir))
                Directory.CreateDirectory(screenshotDir);
        }

        protected Window MainWindow { get; private set; }
        protected MainScreen MainScreen { get; private set; }
        protected Application Application { get; private set; }
        protected ScreenRepository Repository { get; private set; }

        [Fact]
        public void Automate()
        {
            CoreAppXmlConfiguration.Instance.LoggerFactory = new ConsoleFactory(LoggerLevel.Debug);
            var frameworksToRun = SupportedFrameworks();

            foreach (var framework in frameworksToRun)
            {
                currentFramework = framework;
                using (SetMainWindow(framework))
                {
                    try
                    {
                        ExecuteTestRun(framework);
                    }
                    catch (TestFailedException)
                    {
                        throw;
                    }
                    catch (Exception ex)
                    {
                        throw new TestFailedException(string.Format("Failed to run test for {0}", framework), ex);
                    }
                }
            }
            currentFramework = null;
        }

        protected void RunTest(Action testAction, params WindowsFramework[] runFor)
        {
            if (!runFor.Any() || runFor.Any(r => r == currentFramework))
            {
                try
                {
                    testAction();
                }
                catch (Exception ex)
                {
                    string path2 = string.Empty;
                    try
                    {
                        path2 = testAction.Method.Name + ".png";
                        var filename = Path.Combine(screenshotDir, path2);
                        Desktop.CaptureScreenshot().Save(filename, ImageFormat.Png);
                        Trace.WriteLine(string.Format("Screenshot taken: {0}", filename));
                    }
                    catch (Exception)
                    {
                        Trace.TraceError(string.Format("Failed to save screenshot to directory: {0}, filename: {1}", screenshotDir, path2));
                    }
                    throw new TestFailedException(string.Format("Failed to run {0} for {1}. Details:\r\n\r\n{2}", 
                        testAction.Method.Name, currentFramework, ex), ex);
                }
            }
        }

        protected abstract void ExecuteTestRun(WindowsFramework framework);

        private IDisposable SetMainWindow(WindowsFramework framework)
        {
            try
            {
                Keyboard = Keyboard.Instance;
                var configuration = TestConfigurationFactory.Create(framework);
                Application = configuration.LaunchApplication();
                Repository = new ScreenRepository(Application);
                MainWindow = configuration.GetMainWindow(Application);
                MainScreen = configuration.GetMainScreen(Repository);

                return new ShutdownApplicationDisposable(this);
            }
            catch (Exception e)
            {
                logger.Error("Failed to launch application and get main window", e);
                if (Application != null)
                    Application.Close();
                throw;
            }
        }

        protected abstract IEnumerable<WindowsFramework> SupportedFrameworks();

        protected IEnumerable<WindowsFramework> AllFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
            yield return WindowsFramework.Silverlight;
        }

        private class ShutdownApplicationDisposable : IDisposable
        {
            private readonly WhiteTestBase testBase;

            public ShutdownApplicationDisposable(WhiteTestBase testBase)
            {
                this.testBase = testBase;
            }

            public void Dispose()
            {
                foreach (var window in testBase.windowsToClose)
                {
                    if (!window.IsClosed)
                        window.Close();
                }
                testBase.windowsToClose.Clear();
                testBase.MainWindow.Close();
                testBase.Application.Dispose();
                testBase.Application = null;
                testBase.MainWindow = null;
            }
        }

        protected Window StartScenario(string scenarioButtonId, string windowTitle)
        {
            MainWindow.Get<Button>(scenarioButtonId).Click();
            var window = MainWindow.ModalWindow(windowTitle);
            windowsToClose.Add(window);
            return window;
        }

        protected void SelectOtherControls()
        {
            MainWindow.Tabs[0].SelectTabPage(2);
        }

        protected void SelectInputControls()
        {
            MainWindow.Tabs[0].SelectTabPage(1);
        }

        protected void SelectListControls()
        {
            MainWindow.Tabs[0].SelectTabPage(0);
        }

        protected void SelectDataGridTab()
        {
            MainWindow.Tabs[0].SelectTabPage(3);
        }

        protected void SelectPropertyGridTab()
        {
            MainWindow.Tabs[0].SelectTabPage(4);
        }
    }
}