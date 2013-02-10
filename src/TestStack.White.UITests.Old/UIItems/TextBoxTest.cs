using System.Threading;
using System.Windows.Forms;
using NUnit.Framework;
using White.Core.InputDevices;
using White.Core.UITests.Testing;
using White.Core.WindowsAPI;
using TextBox = White.Core.UIItems.TextBox;

namespace White.Core.UITests.UIItems
{
    [TestFixture]
    public class TextBoxTest : ControlsActionTest
    {
        private TextBox textBox;

        protected override void TestFixtureSetUp()
        {
            textBox = Window.Get<TextBox>("textBox");
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
            AttachedKeyboard attachedKeyboard = Window.Keyboard;
            textBox.Text = "userText";
            attachedKeyboard.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
            attachedKeyboard.Enter("ac");
            attachedKeyboard.LeaveKey(KeyboardInput.SpecialKeys.CONTROL);
            Thread.Sleep(100);

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