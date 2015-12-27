using NUnit.Framework;
using System;
using System.Windows;
using TestStack.White.InputDevices;
using TestStack.White.UIA;
using TestStack.White.UIItems;
using TestStack.White.Utility;

namespace TestStack.White.UITests.InputDevices
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class MouseTests : WhiteUITestBase
    {
        public MouseTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [Test]
        public void CursorTest()
        {
            var cursor = Mouse.Instance.Cursor;
            Assert.That(cursor, Is.Not.Null);
        }

        [Test]
        public void LocationTest()
        {
            var mouse = Mouse.Instance;
            var point = new Point(100, 100);
            Assert.That(mouse.Location, Is.Not.EqualTo(point));
            mouse.Location = point;
            Retry.For(() => Assert.That(mouse.Location, Is.EqualTo(point)), TimeSpan.FromSeconds(5));
        }

        [Test]
        public void RightClickTest()
        {
            var button = MainWindow.Get<Button>("ButtonWithTooltip");
            Mouse.Instance.Location = button.Bounds.Center();
            Mouse.Instance.RightClick();
            Retry.For(() => Assert.That(button.Text, Is.EqualTo("Right click received")), TimeSpan.FromSeconds(5));
        }
    }
}