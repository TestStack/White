namespace White.Core.UIItems.Scrolling
{
    public interface IScrollBars
    {
        IHScrollBar Horizontal { get; }
        IVScrollBar Vertical { get; }
        bool CanScroll { get; }
    }

    public abstract class AbstractScrollBars : IScrollBars
    {
        public abstract IHScrollBar Horizontal { get; }
        public abstract IVScrollBar Vertical { get; }

        public virtual bool CanScroll
        {
            get { return !((Horizontal is NullScrollBar) && (Vertical is NullScrollBar)); }
        }
    }
}
