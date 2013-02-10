using NUnit.Framework;

namespace White.WebBrowser.UITests.Silverlight
{
    [TestFixture]
    public class SilverlightApplicationTest : SilverlightTestFixture
    {
        [Test]
        public void FindSilverlightDocument()
        {
            var document = BrowserWindow.SilverlightDocument;
            Assert.AreNotEqual(null, document);
        }
    }
}