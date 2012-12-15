using NUnit.Framework;
using White.Core.InputDevices;
using White.Core.UIItems;
using White.Core.UIItems.TabItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.InputDevices
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
            Mouse.instance.DragAndDrop(textBox, button);
            AssertResultLabelText("TextBoxDraggedOnButton");
        }

        [Test]
        public void DragAndDropOnTab()
        {
            var tab = window.Get<Tab>("seasons");
            Mouse.instance.DragAndDrop(textBox, tab);
            AssertResultLabelText("TextBoxDraggedOnTab");
        }
    }
}