using NUnit.Framework;
using White.Core.Testing;
using White.Core.UIItems;
using White.Core.UIItems.TabItems;

namespace White.Core.InputDevices
{
    [TestFixture, WinFormCategory]
    public class DragAndDropTest : ControlsActionTest
    {
        private TextBox textBox;

        protected override void TestFixtureSetUp()
        {
            textBox = window.Get<TextBox>("textBox");
        }

        [Test]
        public void DragAndDrop()
        {
            var button = window.Get<Button>("buton");
            Mouse.Instance.DragAndDrop(textBox, button);
            AssertResultLabelText("TextBoxDraggedOnButton");
        }

        [Test]
        public void DragAndDropOnTab()
        {
            var tab = window.Get<Tab>("seasons");
            Mouse.Instance.DragAndDrop(textBox, tab);
            AssertResultLabelText("TextBoxDraggedOnTab");
        }
    }
}