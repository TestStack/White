using System.Windows;
using NUnit.Framework;
using White.Core.UIItems.Actions;
using White.Core.WindowsAPI;

namespace White.Core.InputDevices
{
    [TestFixture, NormalCategory]
    public class MouseTest
    {
        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.ESCAPE, new NullActionListener());
        }

        [Test]
        public void Cursor()
        {
            MouseCursor cursor = Mouse.Instance.Cursor;
        }

        [Test]
        public void Location()
        {
            Mouse mouse = Mouse.Instance;
            Point point = new Point(100, 100);
            Assert.AreNotEqual(point, mouse.Location);
            mouse.Location = point;
            Assert.AreEqual(point, mouse.Location);
        }

        [Test]
        public void RightClick()
        {
            Mouse mouse = Mouse.Instance;
            mouse.RightClick();
            mouse.Click();
        }
    }
}