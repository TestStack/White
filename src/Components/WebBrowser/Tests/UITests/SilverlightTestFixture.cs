using System.Diagnostics;
using NUnit.Framework;

namespace White.WebBrowser.UITests
{
    public class SilverlightTestFixture
    {
        protected InternetExplorerWindow browserWindow;

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
            browserWindow = InternetExplorer.Launch("http://localhost/white.testsilverlight/TestSilverlightApplicationTestPage.aspx",
                                                    "TestSilverlightApplication - Windows Internet Explorer");
            PostSetup();
        }

        protected virtual void PostSetup()
        {
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            browserWindow.Dispose();
        }
    }
}