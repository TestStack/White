using NUnit.Framework;

namespace White.WebBrowser.Silverlight
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