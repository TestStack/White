using System.Windows;
using NUnit.Framework;
using White.Core.UIA;

namespace White.Core.UnitTests.UIA
{
    [TestFixture]
    public class WindowsPointXTest
    {
        [Test]
        public void ConvertToDrawingPoint()
        {
            System.Drawing.Point point = new Point(10, 10).ToDrawingPoint();
            Assert.AreEqual(10, point.X);
            Assert.AreEqual(10, point.Y);
        }

        [Test]
        public void IsInvalid()
        {
            Assert.AreEqual(true, new Point(double.PositiveInfinity, 0).IsInvalid());
            Assert.AreEqual(true, new Point(double.NegativeInfinity, 0).IsInvalid());
            Assert.AreEqual(true, new Point(0, double.PositiveInfinity).IsInvalid());
            Assert.AreEqual(true, new Point(0, double.NegativeInfinity).IsInvalid());
            Assert.AreEqual(false, new Point(0, 0).IsInvalid());
        }
    }
}