using System.Drawing;
using White.Core.Drawing;
using Xunit;

namespace TestStack.White.Core.UnitTests.Drawing
{
    public class DrawingPointXTest
    {
        [Fact]
        public void ConvertToWindowsPoint()
        {
            var point = new Point(10, 10);
            System.Windows.Point winPoint = point.ConvertToWindowsPoint();
            Assert.Equal(10, winPoint.X);
            Assert.Equal(10, winPoint.Y);
        }
    }
}