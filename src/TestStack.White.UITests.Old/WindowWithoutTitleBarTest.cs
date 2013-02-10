using NUnit.Framework;
using White.Core.UITests.Testing;

namespace White.Core.UITests
{
    [TestFixture, WinFormCategory]
    public class WindowWithoutTitleBarTest : ControlsActionTest
    {
        protected override string CommandLineArguments
        {
            get { return "NoTitleBar"; }
        }

        [Test]
        public void FindWindow()
        {
            Assert.AreNotEqual(null, Window);
            Assert.AreEqual("Form1", Window.Title);
        }
    }
}