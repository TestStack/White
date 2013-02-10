using NUnit.Framework;
using White.Core.InputDevices;
using White.Core.UIA;
using White.Core.UIItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.InputDevices
{
    [TestFixture, WinFormCategory]
    public class DragAndDropBasedOnPositionTest : ControlsActionTest
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
            Mouse.Instance.DragAndDrop(textBox, textBox.Bounds.ImmediateInteriorEast(), button, button.Bounds.ImmediateInteriorSouth());
            AssertResultLabelText("TextBoxDraggedOnButton");
        }
    }
}