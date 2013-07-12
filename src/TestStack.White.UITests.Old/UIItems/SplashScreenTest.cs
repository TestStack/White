using NUnit.Framework;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    [TestFixture, WinFormCategory, WPFCategory]
    public class SplashScreenTest : CoreTestTemplate
    {
        protected override string CommandLineArguments
        {
            get { return "splash"; }
        }

        [Fact]
        public void FindWindowOnSplashScreen()
        {
            Window splash = Application.FindSplash();
            Assert.IsNotNull(splash);
            Window modalWindow = splash.ModalWindow("Foo", InitializeOption.NoCache);
            Assert.NotEqual(null, modalWindow);
            var okButton = modalWindow.Get<Button>(SearchCriteria.ByText("OK"));
            okButton.Click();
        }
    }
}