using System.Windows;
using TestStack.White.UIA;
using Xunit;

namespace TestStack.White.UnitTests.UIA
{
    public class WindowsPointXTest
    {
        [Fact]
        public void ConvertToDrawingPoint()
        {
            System.Drawing.Point point = new Point(10, 10).ToDrawingPoint();
            Assert.Equal(10, point.X);
            Assert.Equal(10, point.Y);
        }

        [Fact]
        public void IsInvalid()
        {
            Assert.Equal(true, new Point(double.PositiveInfinity, 0).IsInvalid());
            Assert.Equal(true, new Point(double.NegativeInfinity, 0).IsInvalid());
            Assert.Equal(true, new Point(0, double.PositiveInfinity).IsInvalid());
            Assert.Equal(true, new Point(0, double.NegativeInfinity).IsInvalid());
            Assert.Equal(false, new Point(0, 0).IsInvalid());
        }
    }
}