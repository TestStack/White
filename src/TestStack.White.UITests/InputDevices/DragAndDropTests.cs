using System;
using System.Collections.Generic;
using Castle.Core.Logging;
using TestStack.White.InputDevices;
using TestStack.White.UIA;
using TestStack.White.UIItems;
using TestStack.White.Utility;
using Xunit;

namespace TestStack.White.UITests.InputDevices
{
    public class DragAndDropTests : WhiteTestBase
    {
        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            RunTest(DragAndDrop);
            RunTest(DragAndDropBasedOnPosition);
        }

        void DragAndDropBasedOnPosition()
        {
            using (var window = StartScenario("DragDropScenario", "DragAndDropTestWindow"))
            {
                var button = window.Get<Button>("Button");
                var textBox = window.Get<TextBox>("TextBox");

                Mouse.Instance.DragAndDrop(textBox, textBox.Bounds.Center(), button, button.Bounds.Center());

                Retry.For(() => Assert.Equal("TextBoxDraggedOntoButton", window.Get<Label>("DragDropResults").Text),
                    TimeSpan.FromSeconds(2));
            }
        }

        void DragAndDrop()
        {
            using (var window = StartScenario("DragDropScenario", "DragAndDropTestWindow"))
            {
                var button = window.Get<Button>("Button");
                var textBox = window.Get<TextBox>("TextBox");
                Mouse.Instance.DragAndDrop(textBox, button);

                Retry.For(() => Assert.Equal("TextBoxDraggedOntoButton", window.Get<Label>("DragDropResults").Text),
                    TimeSpan.FromSeconds(2));
            }
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
        }
    }
}