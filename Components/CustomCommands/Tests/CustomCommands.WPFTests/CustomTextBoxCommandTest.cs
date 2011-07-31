using NUnit.Framework;
using White.Core.CustomCommands;
using White.Core.UIItems;

namespace White.CustomCommands.WPFTests
{
    [TestFixture]
    public class CustomTextBoxCommandTest : WPFCustomCommandsTest
    {
        [Test]
        public void SelectText()
        {
            var textBox = window.Get<TextBox>("textbox");
            Assert.AreEqual("Foo", textBox.Text);
            textBox.Text = "foobarbaz";
            var wpfTextBoxCommands = new CustomCommandFactory().Create<ITextBoxCommands>(textBox);
            wpfTextBoxCommands.SelectText("bar");
            Assert.AreEqual("foobarbaz", textBox.Text);
        }
    }
}