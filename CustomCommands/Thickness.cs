using System.Runtime.Serialization;

namespace White.CustomCommands
{
    [DataContract]
    public class Thickness
    {
        [DataMember]
        private readonly double bottom;
        [DataMember]
        private readonly double left;
        [DataMember]
        private readonly double right;
        [DataMember]
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