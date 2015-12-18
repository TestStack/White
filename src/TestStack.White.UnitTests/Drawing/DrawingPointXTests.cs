using NUnit.Framework;
using System.Drawing;
using TestStack.White.Drawing;

namespace TestStack.White.UnitTests.Drawing
{
    [TestFixture]
    public class DrawingPointXTests
    {
        [Test]
        public void ConvertToWindowsPointTest()
        {
            var point = new Point(10, 10);
            System.Windows.Point winPoint = point.ConvertToWindowsPoint();
            Assert.That(winPoint.X, Is.EqualTo(10));
            Assert.That(winPoint.Y, Is.EqualTo(10));
        }
    }
}