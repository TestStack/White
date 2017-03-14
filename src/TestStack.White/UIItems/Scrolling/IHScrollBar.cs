namespace TestStack.White.UIItems.Scrolling
{
    public interface IHScrollBar : IScrollBar
    {
        void ScrollLeft();
        void ScrollRight();
        void ScrollLeftLarge();
        void ScrollRightLarge();
        bool IsScrollable { get; }
        bool IsNotMinimum { get; }
    }
}
