using System.Windows;
using NUnit.Framework;
using White.Core.InputDevices;
using White.Core.UIItems.Actions;
using White.Core.WindowsAPI;

namespace White.Core.UITests.InputDevices
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
            MouseCursor cursor = Mouse.instance.Cursor;
        }

        [Test]
        public void Location()
        {
            Mouse mouse = Mouse.instance;
            var point = new Point(100, 100);
            Assert.AreNotEqual(point, mouse.Location);
            mouse.Location = point;
            Assert.AreEqual(point, mouse.Location);
        }

        [Test]
        public void RightClick()
        {
            Mouse mouse = Mouse.instance;
            mouse.RightClick();
            mouse.Click();
        }
    }
}