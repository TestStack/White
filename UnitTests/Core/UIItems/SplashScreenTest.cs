using NUnit.Framework;
using White.Core.Factory;
using White.Core.Testing;
using White.Core.UIItems.Finders;
using White.Core.UIItems.WindowItems;

namespace White.Core.UIItems
{
    [TestFixture, WinFormCategory, WPFCategory]
    public class SplashScreenTest : CoreTestTemplate
    {
        protected override string CommandLineArguments
        {
            get { return "splash"; }
        }

        [Test]
        public void FindWindowOnSplashScreen()
        {
            Window splash = application.FindSplash();
            Assert.IsNotNull(splash);
            Window modalWindow = splash.ModalWindow("Foo", InitializeOption.NoCache);
            Assert.AreNotEqual(null, modalWindow);
            Button okButton = modalWindow.Get<Button>(SearchCriteria.ByText("OK"));
            okButton.Click();
            Assert.AreEqual(true, application.HasExited);
        }
    }
}