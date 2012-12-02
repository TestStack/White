using System.Windows;

namespace White.Core.UIItems.Scrolling
{
    public class NullHScrollBar : NullScrollBar, IHScrollBar
    {
        public virtual void ScrollLeft() {}

        public virtual void ScrollRight() {}

        public virtual void ScrollLeftLarge() {}

        public virtual void ScrollRightLarge() {}

        public virtual bool IsScrollable
        {
            get { return false; }
        }

        public virtual Rect Bounds
        {
            get { return Rect.Empty; }
        }
    }
}
