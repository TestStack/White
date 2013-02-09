using System;
using Castle.Core.Logging;
using NUnit.Framework;
using White.Core.Configuration;
using White.Core.Factory;
using White.Core.InputDevices;
using White.Core.UIItems;
using White.Core.UIItems.WindowItems;

namespace White.Core.UITests.Testing
{
    public class CoreTestTemplate
    {
        protected TestConfiguration TestConfiguration;
        protected Application Application;
        internal Keyboard Keyboard;
        private readonly TestMode testMode = TestMode.Create(Environment.CommandLine);
        private readonly ILogger logger = CoreAppXmlConfiguration.Instance.LoggerFactory.Create(typeof(CoreTestTemplate));

        [TestFixtureSetUp]
        public virtual void LaunchApplication()
        {
            try
            {
                Keyboard = Keyboard.Instance;
                TestConfiguration = testMode.GetConfiguration(CommandLineArguments, this);
                Application = TestConfiguration.Launch();
                BaseTestFixtureSetup();
                TestFixtureSetUp();
            }
            catch (Exception e)
            {
                logger.Error("Failed to launch application", e);
                TextFixtureTearDown();
                throw;
            }
        }

        protected virtual void BaseTestFixtureSetup() {}

        protected virtual void TestFixtureSetUp() {}

        protected virtual string CommandLineArguments
        {
            get { return string.Empty; }
        }

        [TestFixtureTearDown]
        public virtual void TextFixtureTearDown()
        {
            BaseTestFixtureTearDown();
            Application = null;
            TestConfiguration = null;
        }

        protected void CloseModal(Window window)
        {
            Window modalWindow = null;
            try
            {
                modalWindow = window.ModalWindow("ModalForm", InitializeOption.NoCache);
            }
            finally
            {
                if (modalWindow != null) modalWindow.Get<Button>("ok").Click();
            }
        }

        protected virtual void BaseTestFixtureTearDown() {}
    }
}