using NUnit.Framework;
using White.Core.InputDevices;
using White.Core.UIItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.InputDevices
{
    [TestFixture, WinFormCategory]
    public class AttachedKeyboardTest : ControlsActionTest
    {
        [Test]
        public void Enter()
        {
            var textBox = window.Get<TextBox>("textBox");
            textBox.Focus();
            AttachedKeyboard attachedKeyboard = window.Keyboard;
            attachedKeyboard.Enter("a");
            Assert.AreEqual("a", textBox.Text);
        }
    }
}