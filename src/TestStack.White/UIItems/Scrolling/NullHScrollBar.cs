using System.Windows;

namespace TestStack.White.UIItems.Scrolling
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

        public virtual bool IsNotMinimum
        {
            get { return Value > 0; }
        }

        public virtual Rect Bounds
        {
            get { return Rect.Empty; }
        }
    }
}
