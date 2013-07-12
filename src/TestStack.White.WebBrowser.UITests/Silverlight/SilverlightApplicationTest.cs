using Xunit;

namespace TestStack.White.WebBrowser.UITests.Silverlight
{
    public class SilverlightApplicationTest : SilverlightTestFixture
    {
        [Fact]
        public void FindSilverlightDocument()
        {
            var document = BrowserWindow.SilverlightDocument;
            Assert.NotEqual(null, document);
        }
    }
}