using System.Windows;

namespace White.Core.UIItems.Scrolling
{
    public interface IScrollBar
    {
        double Value { get; }
        double MinimumValue { get; }
        double MaximumValue { get; }
        void SetToMinimum();
        void SetToMaximum();
        Rect Bounds { get; }
    }
}