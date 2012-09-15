using NUnit.Framework;
using White.Core;
using White.Core.UIItems.WindowItems;

namespace White.CustomCommands.WPFTests
{
    public abstract class WPFCustomCommandsTest
    {
        private Application application;
        protected Window window;

        [SetUp]
        public void SetUp()
        {
            application = Application.Launch(@"White.CustomCommands.WPFTestApplication.exe");
            window = application.GetWindow("Form1");
        }

        [TearDown]
        public void TearDown()
        {
            application.Kill();
        }
    }
}