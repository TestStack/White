using System;

namespace White.CustomCommands.WPF
{
    [Serializable]
    public class Thickness
    {
        private double bottom;
        private double left;
        private double right;
        private double top;

        public Thickness(System.Windows.Thickness thickness)
        {
            bottom = thickness.Bottom;
            left = thickness.Left;
            right = thickness.Right;
            top = thickness.Top;
        }

        public double Bottom
        {
            get { return bottom; }
        }

        public double Left
        {
            get { return left; }
        }

        public double Right
        {
            get { return right; }
        }

        public double Top
        {
            get { return top; }
        }
    }
}