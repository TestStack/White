using NonCoreTests.WebBrowser;
using NUnit.Framework;
using White.WebBrowser.Silverlight;

namespace White.NonCoreTests.WebBrowser.Silverlight
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