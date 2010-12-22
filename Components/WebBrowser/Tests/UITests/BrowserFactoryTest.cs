using NUnit.Framework;

namespace White.WebBrowser.UITests
{
    [TestFixture]
    public class BrowserFactoryTest
    {
        private FirefoxWindow firefoxWindow;

        [Test, Ignore("UIAutomation not supported in firefox")]
        public void FirefoxTest()
        {
            firefoxWindow = Firefox.Launch("about:blank");
            Assert.AreNotEqual(null, firefoxWindow);
        }

        [TearDown]
        public void TearDown()
        {
            firefoxWindow.Dispose();
        }
    }
}