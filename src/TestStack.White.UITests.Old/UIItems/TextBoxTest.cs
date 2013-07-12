using System.Threading;
using System.Windows.Forms;
using NUnit.Framework;
using TestStack.White.InputDevices;
using TestStack.White.UITests.Testing;
using TestStack.White.WindowsAPI;
using TextBox = White.Core.UIItems.TextBox;

namespace White.Core.UITests.UIItems
{
    public class TextBoxTest : ControlsActionTest
    {
        private TextBox textBox;

        protected override void TestFixtureSetUp()
        {
            textBox = Window.Get<TextBox>("textBox");
        }

        [Fact]
        public void EnterText()
        {
            textBox.Text = "somethingElse";
            Assert.Equal("somethingElse", textBox.Text);
            AssertResultLabelText("Text changed");
            textBox.Text = "";
            Assert.Equal("", textBox.Text);
            textBox.Text = "againSomethingElse";
            Assert.Equal("againSomethingElse", textBox.Text);
        }

        [Fact]
        public void EnterBulkText()
        {
            textBox.BulkText = "somethingElse";
            Assert.Equal("somethingElse", textBox.Text);
        }

        [Fact(Skip = "Not working on the build server for some reason...")]
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
            Assert.Equal(textBox.Text, clipbrdText, "Text on clipboard does not match expected");
        }

        [Fact]
        public void IsReadOnly()
        {
            Assert.Equal(false, textBox.IsReadOnly);
        }
    }
}