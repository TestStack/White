using System.Windows;
using System.Windows.Automation;
using TestStack.White.UIA;

namespace TestStack.White.UIItems.Scrolling
{
    public abstract class WpfScrollBar : IScrollBar
    {
        protected readonly ScrollPattern ScrollPattern;

        protected WpfScrollBar(AutomationElement parent)
        {
            ScrollPattern = parent.GetPattern<ScrollPattern>();
        }

        public abstract double Value { get; }
        protected abstract double ScrollPercentage { get; }

        public virtual double MinimumValue
        {
            get { return 0; }
        }

        public virtual double MaximumValue
        {
            get { return 100; }
        }

        public abstract void SetToMinimum();
        public abstract void SetToMaximum();
        public abstract Rect Bounds { get; }
    }
}
