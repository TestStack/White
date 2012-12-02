namespace White.Core.UIItems.Scrolling
{
    public interface IVScrollBar : IScrollBar
    {
        void ScrollUp();
        void ScrollDown();
        void ScrollUpLarge();
        void ScrollDownLarge();
        bool IsScrollable { get; }
        bool IsNotMinimum { get; }
    }
}