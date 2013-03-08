using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Logging;
using NUnit.Framework;
using TestStack.White.UITests.Infrastructure;
using White.Core;
using White.Core.Configuration;
using White.Core.InputDevices;
using White.Core.UIItems;

namespace TestStack.White.UITests
{
    [TestFixture]
    public abstract class WhiteTestBase
    {
        readonly ILogger logger = CoreAppXmlConfiguration.Instance.LoggerFactory.Create(typeof(WhiteTestBase));
        internal Keyboard Keyboard;
        private WindowsFramework currentFramework;

        protected IMainWindow MainWindow { get; private set; }
        protected Application Application { get; private set; }

        [Test]
        public void RunTest()
        {
            var frameworksToRun = SupportedFrameworks();

            foreach (var framework in frameworksToRun)
            {
                currentFramework = framework;
                using (SetMainWindow(framework))
                {
                    try
                    {
                        RunTest(framework);
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
            if (runFor.Any(r => r.FrameworkId == currentFramework.FrameworkId))
            {
                try
                {
                    testAction();
                }
                catch (Exception ex)
                {
                    throw new TestFailedException(
                        string.Format("Failed to run {0} for {1}", testAction.Method.Name, currentFramework), ex);
                }
            }
        }

        protected abstract void RunTest(WindowsFramework framework);

        private IDisposable SetMainWindow(WindowsFramework framework)
        {
            try
            {
                Keyboard = Keyboard.Instance;
                var configuration = TestConfigurationFactory.Create(framework);
                Application = configuration.LaunchApplication();
                MainWindow = configuration.GetMainWindow(Application);

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
                testBase.MainWindow.Close();
                if (!testBase.Application.HasExited)
                {
                    // ReSharper disable EmptyGeneralCatchClause
                    try
                    {
                        testBase.Application.Close();
                    }
                    catch (Exception)
                    {}
                    // ReSharper restore EmptyGeneralCatchClause
                }
                testBase.Application = null;
                testBase.MainWindow = null;
            }
        }
    }
}