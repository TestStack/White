using System.Windows;

namespace TestStack.White
{
    public class HorizontalSpan : Span
    {
        public HorizontalSpan(Rect bounds) : base(bounds.Left, bounds.Right) {}

        public virtual bool IsOutside(Rect rect)
        {
            return DoesntContain(rect, rect.Left, rect.Right);
        }

        public virtual bool DoesntContain(Rect rect)
        {
            return DoesntContain(rect, rect.Left, rect.Right);
        }

        public virtual bool Contains(Rect rect)
        {
            return !DoesntContain(rect);
        }
    }
}