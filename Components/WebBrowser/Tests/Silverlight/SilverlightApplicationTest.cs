using NUnit.Framework;
using White.NonCoreTests.WebBrowser;
using White.WebBrowser.Silverlight;

namespace White.WebBrowser.Tests.Silverlight
{
    [TestFixture]
    public class SilverlightApplicationTest : SilverlightTestFixture
    {
        [Test]
        public void FindSilverlightDocument()
        {
            SilverlightDocument document = browserWindow.SilverlightDocument;
            Assert.AreNotEqual(null, document);
        }
    }
}