using NUnit.Framework;
using White.Core.CustomCommands;
using White.Core.UIItems;
using White.CustomCommands.WPF;
using White.UnitTests.Core.Testing;

namespace White.UnitTests.Core.CustomCommands
{
    [TestFixture]
    public class CustomTextBoxCommandTest : ControlsActionTest
    {
        protected override string CommandLineArguments
        {
            get { return "CustomWhiteControlsWindow"; }
        }

        [Test]
        public void SelectText()
        {
            var textBox = window.Get<TextBox>("textbox");
            textBox.Text = "foobarbaz";
            var wpfTextBoxCommands = new CustomCommandFactory().Create<ITextBoxCommands>(textBox);
            wpfTextBoxCommands.SelectText("bar");
            Assert.AreEqual("foobarbaz", textBox.Text);
        }
    }
}