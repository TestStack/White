using System;
using System.Collections.Generic;
using Castle.Core.Logging;
using NUnit.Framework;
using TestStack.White.UITests.Infrastructure;
using White.Core;
using White.Core.Configuration;
using White.Core.InputDevices;

namespace TestStack.White.UITests
{
    [TestFixture]
    public abstract class WhiteTestBase
    {
        readonly ILogger logger = CoreAppXmlConfiguration.Instance.LoggerFactory.Create(typeof(WhiteTestBase));
        internal Keyboard Keyboard;
        private FrameworkId? currentFramework;

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

        protected void RunTest(Action testAction)
        {
            try
            {
                testAction();
            }
            catch (Exception ex)
            {
                throw new TestFailedException(string.Format("Failed to run {0} for {1}", testAction.Method.Name, currentFramework), ex);
            }
        }

        protected void RunTest(Action testAction, FrameworkId runFor)
        {
            if ((runFor & currentFramework) != currentFramework) return;
            try
            {
                testAction();
            }
            catch (Exception ex)
            {
                throw new TestFailedException(string.Format("Failed to run {0} for {1}", testAction.Method.Name, currentFramework), ex);
            }
        }

        protected abstract void RunTest(FrameworkId framework);

        private IDisposable SetMainWindow(FrameworkId framework)
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

        protected abstract IEnumerable<FrameworkId> SupportedFrameworks();

        protected IEnumerable<FrameworkId> AllFrameworks()
        {
            yield return FrameworkId.Wpf;
            yield return FrameworkId.Winforms;
            yield return FrameworkId.Silverlight;
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