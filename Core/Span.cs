using System.Windows;
using White.Core.SystemExtensions;

namespace White.Core
{
    public class Span
    {
        protected double start;
        protected double end;

        protected Span(double start, double end)
        {
            this.start = start;
            this.end = end;
        }

        public override string ToString()
        {
            return string.Format("Start: {0}, End: {1}", start, end);
        }

        protected virtual bool DoesntContain(Rect rect, double otherStart, double otherEnd)
        {
            if (rect.Equals(Rect.Empty)) return true;
            double center = (otherStart + otherEnd)/2;
            if (center.IsInvalid()) return true;
            return center < start || center > end;
        }

        public virtual double Start
        {
            get { return start; }
        }

        public virtual double End
        {
            get { return end; }
        }
    }
}