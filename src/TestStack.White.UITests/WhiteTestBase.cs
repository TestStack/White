using System;
using System.Collections.Generic;
using NUnit.Framework;
using TestStack.White.UITests.Infrastructure;
using White.Core.InputDevices;
using log4net;

namespace TestStack.White.UITests
{
    public class WhiteTestBase
    {
        readonly Dictionary<FrameworkId, MainScreen> windows = new Dictionary<FrameworkId, MainScreen>();
        readonly ILog logger = LogManager.GetLogger(typeof(WhiteTestBase));
        internal Keyboard Keyboard;

        public MainScreen GetMainWindow(FrameworkId framework)
        {
            try
            {
                Keyboard = Keyboard.Instance;
                if (!windows.ContainsKey(framework))
                {
                    var configuration = TestConfigurationFactory.Create(framework);
                    var application = configuration.LaunchApplication();
                    var mainWindow = application.GetWindow(configuration.MainWindowTitle);
                    windows.Add(framework, new MainScreen(application, mainWindow));
                }

                return windows[framework];
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;
            }
        }

        [TestFixtureTearDown]
        public void Teardown()
        {
            foreach (var mainScreen in windows)
            {
                mainScreen.Value.Application.Close();
            }
        }
    }
}