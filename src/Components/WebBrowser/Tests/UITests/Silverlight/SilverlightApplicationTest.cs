using NUnit.Framework;
using White.WebBrowser.Silverlight;

namespace White.WebBrowser.UITests.Silverlight
{
    [TestFixture]
    public class SilverlightApplicationTest : SilverlightTestFixture
    {
        [Test]
        public void FindSilverlightDocument()
        {
            SilverlightDocument document = BrowserWindow.SilverlightDocument;
            Assert.AreNotEqual(null, document);
        }
    }
}