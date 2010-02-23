namespace White.CustomCommands.Silverlight
{
    public class Thickness
    {
        private readonly double bottom;
        private readonly double left;
        private readonly double right;
        private readonly double top;

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