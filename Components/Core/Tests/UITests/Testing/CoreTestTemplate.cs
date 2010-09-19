using System;
using NUnit.Framework;
using White.Core.Factory;
using White.Core.InputDevices;
using White.Core.Logging;
using White.Core.UIItems;
using White.Core.UIItems.WindowItems;

namespace White.Core.UITests.Testing
{
    public class CoreTestTemplate
    {
        protected Application application;
        private readonly TestMode testMode = TestMode.Create(Environment.CommandLine);
        internal Keyboard keyboard;
        protected TestConfiguration testConfiguration;

        [TestFixtureSetUp]
        public virtual void LaunchApplication()
        {
            try
            {
                keyboard = Keyboard.Instance;
                testConfiguration = testMode.GetConfiguration(CommandLineArguments, this);
                application = testConfiguration.Launch();
                BaseTestFixtureSetup();
                TestFixtureSetUp();
            }
            catch (Exception e)
            {
                WhiteLogger.Instance.Error(e);
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
            application = null;
            testConfiguration = null;
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