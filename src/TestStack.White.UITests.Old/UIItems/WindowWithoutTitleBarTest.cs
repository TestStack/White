using NUnit.Framework;
using TestStack.White.Factory;
using TestStack.White.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    [TestFixture, WinFormCategory]
    public class WindowWithoutTitleBarTest : CoreTestTemplate
    {
        protected override string CommandLineArguments
        {
            get { return "notitle"; }
        }

        [Fact]
        public void FindWindowOnSplashScreen()
        {
            Assert.NotEqual(null, Application.GetWindow("Form1", InitializeOption.NoCache));
        }

        public override void TextFixtureTearDown()
        {
            Application.Kill();
        }
    }
}