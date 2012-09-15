using NUnit.Framework;
using White.Core.CustomCommands;
using White.Core.UIItems;
using White.WebBrowser.UITests;

namespace White.CustomCommands.SilverlightTests
{
    [TestFixture]
    public class CustomButtonCommandSilverlightTest : SilverlightTestFixture
    {
        [Test]
        public void GetBorderThickness()
        {
            var button = browserWindow.SilverlightDocument.Get<Button>("buton");
            var wpfWhiteButton = new CustomCommandFactory().Create<IButtonCommands>(button);
            Assert.AreEqual(1, wpfWhiteButton.BorderBottomThickness);
        }
    }
}