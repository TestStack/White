using NUnit.Framework;
using White.Core.CustomCommands;
using White.Core.UIItems;
using White.CustomCommands.Silverlight;
using White.NonCoreTests.WebBrowser;

namespace White.NonCoreTests.CustomCommands
{
    [TestFixture]
    public class CustomButtonCommandSilverlightTest : SilverlightTestFixture
    {
        [Test]
        public void GetBorderThickness()
        {
            var button = browserWindow.SilverlightDocument.Get<Button>("buton");
            var wpfWhiteButton = new CustomCommandFactory().Create<IButtonCommands>(button);
            Assert.AreNotEqual(0, wpfWhiteButton.BottomBorderThickness);
        }
    }
}