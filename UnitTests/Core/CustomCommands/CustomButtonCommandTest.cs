using NUnit.Framework;
using White.Core.CustomCommands;
using White.Core.UIItems;
using White.CustomCommands;
using White.UnitTests.Core.Testing;

namespace White.UnitTests.Core.CustomCommands
{
    [TestFixture]
    public class CustomButtonCommandTest : ControlsActionTest
    {
        protected override string CommandLineArguments
        {
            get { return "CustomWhiteControlsWindow"; }
        }

        [Test, Ignore("Doesn't work yet")]
        public void GetBorderThickness()
        {
            var button = window.Get<Button>("button");
            var wpfWhiteButton = new CustomCommandFactory().Create<IButtonCommands>(button);
            Thickness thickness = wpfWhiteButton.BorderThickness;
            Assert.AreNotEqual(0, thickness.Bottom);
        }
    }
}