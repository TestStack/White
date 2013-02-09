using System.Windows;
using System.Windows.Automation;

namespace White.Core.UIItems.Scrolling
{
    public abstract class WPFScrollBar : IScrollBar
    {
        protected readonly ScrollPattern scrollPattern;

        protected delegate void ScrollBackLarge();

        protected delegate void ScrollForwardLarge();

        private delegate void Scroll();

        protected WPFScrollBar(AutomationElement parent)
        {
            scrollPattern = (ScrollPattern) parent.GetCurrentPattern(ScrollPattern.Pattern);
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

        protected virtual void SetToMaximum(ScrollForwardLarge scrollForwardLarge)
        {
            MoveTo(100.0, () => scrollForwardLarge());
        }

        private void MoveTo(double value, Scroll scroll)
        {
            double beforeScrollValue = Value;
            double beforeScrollPercentage = ScrollPercentage;
            while (!(value).Equals(beforeScrollValue))
            {
                scroll();
                double currentScrollValue = Value;
                double currentScrollPercentage = ScrollPercentage;

                CheckChangeInScrollPosition(beforeScrollValue, currentScrollValue, beforeScrollPercentage, currentScrollPercentage);
                
                beforeScrollValue = currentScrollValue;
                beforeScrollPercentage = currentScrollPercentage;
            }
        }

        private void CheckChangeInScrollPosition(double beforeScrollValue, double currentValue, double beforeScrollPercentage, double currentScrollPercentage)
        {
            if (beforeScrollValue == currentValue && beforeScrollPercentage == currentScrollPercentage)
            {
                throw new UIActionException("Cannot set the scroll bar to the start position");
            }
        }

        protected virtual void SetToMinimum(ScrollBackLarge scrollBackLarge)
        {
            MoveTo(0.0, () => scrollBackLarge());
        }
    }
}
