using Bricks;
using NUnit.Framework;
using White.UnitTests.Core.Testing;

namespace White.Core.UIItems.TextBoxes
{
    [TestFixture, WinFormCategory]
    public class PasswordTextBoxTest : ControlsActionTest
    {
        protected override string CommandLineArguments
        {
            get { return "Password"; }
        }

        [Test, ExpectedException(typeof(BricksException))]
        public void CannotGetTextFromPassword()
        {
            TextBox textBox = window.Get<TextBox>("textBox1");
            textBox.BulkText = "foobar";
            string text = textBox.Text;
        }

        [Test]
        public void GetPasswordValueWhenTextBoxIsNotPasswordField()
        {
            TextBox textBox = window.Get<TextBox>("textBox1");
            textBox.BulkText = "foobar";
            window.Get<Button>("button1").Click();
            textBox = window.Get<TextBox>("textBox1");
            string text = textBox.Text;
            Assert.AreEqual("foobar", text);
        }
    }
}