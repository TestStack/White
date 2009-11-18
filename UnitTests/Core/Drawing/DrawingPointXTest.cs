using System.Drawing;
using NUnit.Framework;

namespace White.Core.Drawing
{
    [TestFixture, NormalCategory]
    public class DrawingPointXTest
    {
        [Test]
        public void ConvertToWindowsPoint()
        {
            var point = new Point(10, 10);
            System.Windows.Point winPoint = point.ConvertToWindowsPoint();
            Assert.AreEqual(10, winPoint.X);
            Assert.AreEqual(10, winPoint.Y);
        }
    }
}