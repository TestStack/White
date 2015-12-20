using Xunit;

namespace TestStack.White.WebBrowser.UITests.Silverlight
{
    public class SilverlightApplicationTest : SilverlightTestFixture
    {
        [Fact(Skip = "Ignoring broken tests in silverlight for the moment")]
        public void FindSilverlightDocument()
        {
            var document = BrowserWindow.SilverlightDocument;
            Assert.NotEqual(null, document);
        }
    }
}