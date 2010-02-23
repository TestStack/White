using NonCoreTests.WebBrowser;
using NUnit.Framework;
using White.Core.CustomCommands;
using White.Core.UIItems;
using White.CustomCommands.Silverlight;

namespace White.NonCoreTests.CustomCommands
{
    [TestFixture]
    public class CustomButtonCommandSilverlightTest : SilverlightTestFixture
    {
        [Test]
        public void GetBorderThickness()
        {
            var button = browserWindow.SilverlightDocument.Get<Button>("button");
            var wpfWhiteButton = new CustomCommandFactory().Create<IButtonCommands>(button);
            Thickness thickness = wpfWhiteButton.BorderThickness;
            Assert.AreNotEqual(0, thickness.Bottom);
        }
    }
}