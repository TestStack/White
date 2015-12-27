using NUnit.Framework;

namespace TestStack.White.WebBrowser.UITests
{
    [TestFixture]
    public class BrowserFactoryTest
    {
        [Test]
        [Ignore("UIAutomation not supported in firefox")]
        public void FirefoxTest()
        {
            FirefoxWindow firefoxWindow = null;
            try
            {
                firefoxWindow = Firefox.Launch("about:blank");
                Assert.That(firefoxWindow, Is.Not.Null);
            }
            finally
            {
                if (firefoxWindow != null)
                {
                    firefoxWindow.Dispose();
                }
            }
        }
    }
}