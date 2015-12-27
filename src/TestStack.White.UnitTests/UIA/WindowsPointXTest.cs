using System.Windows;
using NUnit.Framework;
using TestStack.White.UIA;

namespace TestStack.White.UnitTests.UIA
{
    [TestFixture]
    public class WindowsPointXTest
    {
        [Test]
        public void ConvertToDrawingPoint()
        {
            var point = new Point(10, 10).ToDrawingPoint();
            Assert.That(point.X, Is.EqualTo(10));
            Assert.That(point.Y, Is.EqualTo(10));
        }

        [Test]
        public void IsInvalid()
        {
            Assert.That(new Point(double.PositiveInfinity, 0).IsInvalid(), Is.True);
            Assert.That(new Point(double.NegativeInfinity, 0).IsInvalid(), Is.True);
            Assert.That(new Point(0, double.PositiveInfinity).IsInvalid(), Is.True);
            Assert.That(new Point(0, double.NegativeInfinity).IsInvalid(), Is.True);
            Assert.That(new Point(0, 0).IsInvalid(), Is.False);
        }
    }
}