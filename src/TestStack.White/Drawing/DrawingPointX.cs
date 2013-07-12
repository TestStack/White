using System.Drawing;

namespace TestStack.White.Drawing
{
    public static class DrawingPointX
    {
        public static System.Windows.Point ConvertToWindowsPoint(this Point point)
        {
            return new System.Windows.Point(point.X, point.Y);
        }
    }
}