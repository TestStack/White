using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems.TextBoxes
{
    [TestFixture, WinFormCategory]
    public class PasswordTextBoxTest : ControlsActionTest
    {
        protected override string CommandLineArguments
        {
            get { return "Password"; }
        }

        [Test]
        public void CannotGetTextFromPassword()
        {
            var textBox = window.Get<TextBox>("textBox1");
            textBox.BulkText = "foobar";
            var exception = Assert.Throws<WhiteException>(() => { var text = textBox.Text; });
            Assert.AreEqual("Text cannot be retrieved from textbox which has secret text (e.g. password) stored in it", exception.Message);
        }

        [Test]
        public void GetPasswordValueWhenTextBoxIsNotPasswordField()
        {
            var textBox = window.Get<TextBox>("textBox1");
            textBox.BulkText = "foobar";
            window.Get<Button>("button1").Click();
            textBox = window.Get<TextBox>("textBox1");
            string text = textBox.Text;
            Assert.AreEqual("foobar", text);
        }
    }
}