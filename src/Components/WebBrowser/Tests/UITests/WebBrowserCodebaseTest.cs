using Bricks.RuntimeFramework;
using NUnit.Framework;

namespace White.WebBrowser.UITests
{
    [TestFixture]
    public class WebBrowserCodebaseTest
    {
        [Test]
        public void AllMethodsAreVirtual()
        {
            AssemblyTest.AllMethodsVirtual(typeof(Firefox).Assembly);
        }
    }
}