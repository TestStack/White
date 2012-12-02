using System.Windows;
using White.Core.SystemExtensions;

namespace White.Core.UIA
{
    public static class WindowsPointX
    {
        public static System.Drawing.Point ToDrawingPoint(this Point point)
        {
            return new System.Drawing.Point((int) point.X, (int) point.Y);
        }

        public static bool IsInvalid(this Point point)
        {
            return point.X.IsInvalid() || point.Y.IsInvalid();
        }
    }
}