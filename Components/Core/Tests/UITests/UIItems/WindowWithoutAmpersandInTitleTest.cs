using NUnit.Framework;
using White.Core.Factory;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    [TestFixture, WinFormCategory]
    public class WindowWithoutAmpersandInTitleTest : CoreTestTemplate
    {
        protected override string CommandLineArguments
        {
            get { return "ampersand"; }
        }

        [Test]
        public void FindWindowOnSplashScreen()
        {
            Assert.AreNotEqual(null, application.GetWindow("Form&1", InitializeOption.NoCache));
        }

        public override void TextFixtureTearDown()
        {
            application.Kill();
        }
    }
}