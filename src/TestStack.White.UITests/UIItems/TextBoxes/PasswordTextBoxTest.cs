using System.Reflection;
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

        [Test, ExpectedException(typeof(TargetInvocationException))]
        public void CannotGetTextFromPassword()
        {
            var textBox = window.Get<TextBox>("textBox1");
            textBox.BulkText = "foobar";
            string text = textBox.Text;
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