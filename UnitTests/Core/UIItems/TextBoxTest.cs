using System.Windows;
using System.Windows.Forms;
using NUnit.Framework;
using White.Core.InputDevices;
using White.Core.Testing;
using White.Core.WindowsAPI;

namespace White.Core.UIItems
{
    [TestFixture]
    public class TextBoxTest : ControlsActionTest
    {
        private TextBox textBox;

        protected override void TestFixtureSetUp()
        {
            textBox = window.Get<TextBox>("textBox");
        }

        [Test]
        public void EnterText()
        {
            textBox.Text = "somethingElse";
            Assert.AreEqual("somethingElse", textBox.Text);
            AssertResultLabelText("Text changed");
            textBox.Text = "";
            Assert.AreEqual("", textBox.Text);
            textBox.Text = "againSomethingElse";
            Assert.AreEqual("againSomethingElse", textBox.Text);
        }

        [Test]
        public void EnterBulkText()
        {
            textBox.BulkText = "somethingElse";
            Assert.AreEqual("somethingElse", textBox.Text);
        }

        [Test]
        public void CopyTest()
        {
            textBox.Text = "userText";
            textBox.DoubleClick();

            AttachedKeyboard attachedKeyboard = window.Keyboard;
            attachedKeyboard.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
            attachedKeyboard.Enter("c");
            attachedKeyboard.LeaveKey(KeyboardInput.SpecialKeys.CONTROL);

            //check the text is the same as that on the clipboard
            string clipbrdText = Clipboard.GetText();
            Assert.AreEqual(textBox.Text, clipbrdText, "Text on clipboard does not match expected");
        }

        [Test]
        public void IsReadOnly()
        {
            Assert.AreEqual(false, textBox.IsReadOnly);
        }
    }
}