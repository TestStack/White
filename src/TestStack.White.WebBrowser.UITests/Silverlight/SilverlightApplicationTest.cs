using NUnit.Framework;

namespace TestStack.White.WebBrowser.UITests.Silverlight
{
    [TestFixture]
    [Ignore("Ignoring broken tests in silverlight for the moment")]
    public class SilverlightApplicationTest : SilverlightTestFixture
    {
        [Test]
        [Ignore("Ignoring broken tests in silverlight for the moment")]
        public void FindSilverlightDocument()
        {
            var document = BrowserWindow.SilverlightDocument;
            Assert.That(document, Is.Not.Null);
        }
    }
}