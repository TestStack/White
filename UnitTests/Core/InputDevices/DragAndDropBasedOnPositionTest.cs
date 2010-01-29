using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UIA;
using White.UnitTests.Core.Testing;

namespace White.Core.InputDevices
{
    [TestFixture, WinFormCategory]
    public class DragAndDropBasedOnPositionTest : ControlsActionTest
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
            Mouse.Instance.DragAndDrop(textBox, textBox.Bounds.ImmediateInteriorEast(), button, button.Bounds.ImmediateInteriorSouth());
            AssertResultLabelText("TextBoxDraggedOnButton");
        }
    }
}