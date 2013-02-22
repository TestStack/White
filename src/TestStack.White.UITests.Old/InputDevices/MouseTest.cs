using System.Threading;
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
            MouseCursor cursor = Mouse.Instance.Cursor;

            Assert.NotNull(cursor);
        }

        [Test]
        public void Location()
        {
            Mouse mouse = Mouse.Instance;
            var point = new Point(100, 100);
            Assert.AreNotEqual(point, mouse.Location);
            mouse.Location = point;
            Thread.Sleep(100);
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