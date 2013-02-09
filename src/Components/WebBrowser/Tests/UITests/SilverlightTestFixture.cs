using System.Diagnostics;
using NUnit.Framework;

namespace White.WebBrowser.UITests
{
    public abstract class SilverlightTestFixture
    {
        protected InternetExplorerWindow BrowserWindow;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            Process[] processes = Process.GetProcessesByName("iexplore");
            foreach (var process in processes)
            {
                try
                {
                    process.Kill();
                }
                catch
                {
                }
            }
            BrowserWindow = InternetExplorer.Launch("http://localhost/TestSilverlightApplication.Web/TestSilverlightApplicationTestPage.aspx",
                                                    "TestSilverlightApplication - Windows Internet Explorer");
            PostSetup();
        }

        protected virtual void PostSetup()
        {
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            BrowserWindow.Dispose();
        }
    }
}