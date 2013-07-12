using System;
using Xunit;

namespace White.WebBrowser.UITests
{
    public class BrowserFactoryTest : IDisposable
    {
        private FirefoxWindow firefoxWindow;

        [Fact(Skip = "UIAutomation not supported in firefox")]
        public void FirefoxTest()
        {
            firefoxWindow = Firefox.Launch("about:blank");
            Assert.NotEqual(null, firefoxWindow);
        }

        public void TearDown()
        {
        }

        public void Dispose()
        {
            firefoxWindow.Dispose();
        }
    }
}