using NUnit.Framework;
using System;
using TestStack.White.InputDevices;
using TestStack.White.UIA;
using TestStack.White.UIItems;
using TestStack.White.Utility;

namespace TestStack.White.UITests.InputDevices
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class DragAndDropTests : WhiteUITestBase
    {
        public DragAndDropTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [Test]
        public void DragAndDropBasedOnPositionTest()
        {
            using (var window = StartScenario("DragDropScenario", "DragAndDropTestWindow"))
            {
                var button = window.Get<Button>("Button");
                var textBox = window.Get<TextBox>("TextBox");
                var mouse = new Mouse();
                mouse.DragAndDrop(textBox, textBox.Bounds.Center(), button, button.Bounds.Center());

                Retry.For(() => Assert.That(window.Get<Label>("DragDropResults").Text, Is.EqualTo("TextBoxDraggedOntoButton")),
                    TimeSpan.FromSeconds(2));
            }
        }

        [Test]
        public void DragAndDropTest()
        {
            using (var window = StartScenario("DragDropScenario", "DragAndDropTestWindow"))
            {
                var button = window.Get<Button>("Button");
                var textBox = window.Get<TextBox>("TextBox");
                var mouse = new Mouse();
                mouse.DragAndDrop(textBox, button);

                Retry.For(() => Assert.That(window.Get<Label>("DragDropResults").Text, Is.EqualTo("TextBoxDraggedOntoButton")),
                    TimeSpan.FromSeconds(2));
            }
        }
    }
}