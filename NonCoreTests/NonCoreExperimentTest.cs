using System.Threading;
using NUnit.Framework;
using White.Core.UIItems.Finders;
using White.WebBrowser;

namespace White.NonCoreTests
{
    [TestFixture, Ignore]
    public class NonCoreExperimentTest
    {
        [Test]
        public void TestName()
        {
            var window = InternetExplorer.Launch("http://localhost/imdclient", "IMDClient - Windows Internet Explorer");
            var silverlightDocument = window.SilverlightDocument;
            Thread.Sleep(5000);
            var menuBar = silverlightDocument.GetMenuBar(SearchCriteria.ByAutomationId("MainMenu"));
            Assert.AreNotEqual(null, menuBar);
        }
    }
}