using NUnit.Framework;
using White.Core.Testing;

namespace White.Core
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
            Assert.AreNotEqual(null, window);
            Assert.AreEqual("Form1", window.Title);
        }
    }
}