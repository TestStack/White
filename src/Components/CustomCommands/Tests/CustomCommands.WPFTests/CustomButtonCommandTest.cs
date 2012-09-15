using NUnit.Framework;
using White.Core.CustomCommands;
using White.Core.UIItems;

namespace White.CustomCommands.WPFTests
{
    [TestFixture]
    public class CustomButtonCommandTest : WPFCustomCommandsTest
    {
        [Test]
        public void GetBorderThickness()
        {
            CustomCommandSerializer.AddKnownTypes(typeof (Thickness));
            var button = window.Get<Button>("button");
            var wpfWhiteButton = new CustomCommandFactory().Create<IButtonCommands>(button);
            Thickness thickness = wpfWhiteButton.BorderThickness;
            Assert.AreNotEqual(0, thickness.Bottom);
        }
    }
}