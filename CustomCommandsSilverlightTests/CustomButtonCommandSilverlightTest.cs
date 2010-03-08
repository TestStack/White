using System.Threading;
using NUnit.Framework;
using White.Core.CustomCommands;
using White.Core.UIItems;
using White.CustomCommands;
using White.NonCoreTests.WebBrowser;

namespace White.CustomCommandsSilverlightTests
{
    [TestFixture]
    public class CustomButtonCommandSilverlightTest : SilverlightTestFixture
    {
        [Test]
        public void GetBorderThickness()
        {
            var button = browserWindow.SilverlightDocument.Get<Button>("buton");
            var wpfWhiteButton = new CustomCommandFactory().Create<IButtonCommands>(button);
//            Thread.Sleep(10000);
            Assert.AreEqual(1, wpfWhiteButton.BorderBottomThickness);
        }
    }
}