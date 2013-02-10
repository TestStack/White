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
            textBox = Window.Get<TextBox>("textBox");
        }

        [Test]
        public void DragAndDrop()
        {
            var button = Window.Get<Button>("buton");
            Mouse.Instance.DragAndDrop(textBox, button);
            AssertResultLabelText("TextBoxDraggedOnButton");
        }

        [Test]
        public void DragAndDropOnTab()
        {
            var tab = Window.Get<Tab>("seasons");
            Mouse.Instance.DragAndDrop(textBox, tab);
            AssertResultLabelText("TextBoxDraggedOnTab");
        }
    }
}