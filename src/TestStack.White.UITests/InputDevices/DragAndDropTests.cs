using System.Collections.Generic;
using White.Core.InputDevices;
using White.Core.UIA;
using White.Core.UIItems;
using Xunit;

namespace TestStack.White.UITests.InputDevices
{
    public class DragAndDropTests : WhiteTestBase
    {
        [Fact]
        public void DragAndDropBasedOnPosition()
        {
            var window = StartScenario("DragDropScenario", "DragAndDropTestWindow");
            var button = window.Get<Button>("buton");
            var textBox = window.Get<TextBox>("TextBox");

            Mouse.Instance.DragAndDrop(textBox, textBox.Bounds.Center(), button, button.Bounds.Center());

            Assert.Equal("TextBoxDraggedOntoButton", MainWindow.Get<Label>("DragDropResults").Text);
        }

        [Fact]
        public void DragAndDrop()
        {
            var window = StartScenario("DragDropScenario", "DragAndDropTestWindow");
            var button = window.Get<Button>("Button");
            var textBox = window.Get<TextBox>("TextBox");
            Mouse.Instance.DragAndDrop(textBox, button);

            Assert.Equal("TextBoxDraggedOntoButton", MainWindow.Get<Label>("DragDropResults").Text);
        }

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            RunTest(DragAndDrop);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
        }
    }
}