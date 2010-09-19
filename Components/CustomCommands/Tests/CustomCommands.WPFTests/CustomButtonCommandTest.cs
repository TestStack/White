using NUnit.Framework;
using White.Core;
using White.Core.CustomCommands;
using White.Core.UIItems;
using White.CustomCommands;
using White.Core.UnitTests.Testing;

namespace White.Core.UnitTests.CustomCommands
{
    [TestFixture, WPFCategory]
    public class CustomButtonCommandTest : ControlsActionTest
    {
        protected override string CommandLineArguments
        {
            get { return "CustomWhiteControlsWindow"; }
        }

        [Test]
        public void GetBorderThickness()
        {
            CustomCommandSerializer.AddKnownTypes(typeof(Thickness));
            var button = window.Get<Button>("button");
            var wpfWhiteButton = new CustomCommandFactory().Create<IButtonCommands>(button);
            Thickness thickness = wpfWhiteButton.BorderThickness;
            Assert.AreNotEqual(0, thickness.Bottom);
        }
    }
}