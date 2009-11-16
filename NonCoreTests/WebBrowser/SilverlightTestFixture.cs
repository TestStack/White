using NUnit.Framework;

namespace White.WebBrowser.Silverlight
{
    public class SilverlightTestFixture
    {
        protected InternetExplorerWindow browserWindow;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            browserWindow = InternetExplorer.Launch("http://localhost/white.testsilverlight/TestSilverlightApplicationTestPage.aspx", "TestSilverlightApplication - Windows Internet Explorer");
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