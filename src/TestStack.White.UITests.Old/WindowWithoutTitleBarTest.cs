using NUnit.Framework;
using TestStack.White.UITests.Testing;

namespace White.Core.UITests
{
    [TestFixture, WinFormCategory]
    public class WindowWithoutTitleBarTest : ControlsActionTest
    {
        protected override string CommandLineArguments
        {
            get { return "NoTitleBar"; }
        }

        [Fact]
        public void FindWindow()
        {
            Assert.NotEqual(null, Window);
            Assert.Equal("Form1", Window.Title);
        }
    }
}