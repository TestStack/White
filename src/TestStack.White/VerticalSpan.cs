using System.Windows;

namespace White.Core
{
    public class VerticalSpan : Span
    {
        public VerticalSpan(Rect bounds) : base(bounds.Top, bounds.Bottom) {}

        public VerticalSpan(double start, double end) : base(start, end)
        {
        }

        public virtual bool DoesntContain(Rect rect)
        {
            return DoesntContain(rect, rect.Top, rect.Bottom);
        }

        public virtual bool Contains(Rect rect)
        {
            return !DoesntContain(rect);
        }

        public virtual VerticalSpan Union(Rect rect)
        {
            double newStart = rect.Top < start ? rect.Top : start;
            double newEnd = rect.Bottom > end ? rect.Bottom : end;
            return new VerticalSpan(newStart, newEnd);
        }

        public virtual VerticalSpan Minus(Rect rect)
        {
            if (rect.Top > start && rect.Top < end)
                return new VerticalSpan(start, rect.Top);
            return this;
        }
    }
}