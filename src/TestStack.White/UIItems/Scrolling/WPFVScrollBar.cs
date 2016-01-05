using System.Windows;
using System.Windows.Automation;
using TestStack.White.UIItems.Actions;
using Action = TestStack.White.UIItems.Actions.Action;

namespace TestStack.White.UIItems.Scrolling
{
    [PlatformSpecificItem(ReferAsType = typeof (IVScrollBar))]
    public class WpfVScrollBar : WpfScrollBar, IVScrollBar
    {
        private readonly IActionListener actionListener;

        public WpfVScrollBar(AutomationElement parent, IActionListener actionListener) : base(parent)
        {
            this.actionListener = actionListener;
        }

        protected override double ScrollPercentage
        {
            get { return ScrollPattern.Current.VerticalViewSize; }
        }

        public override double Value
        {
            get { return ScrollPattern.Current.VerticalScrollPercent; }
        }

        public override Rect Bounds
        {
            get { return Rect.Empty; }
        }

        public virtual void ScrollUp()
        {
            Scroll(ScrollAmount.SmallDecrement);
        }

        public virtual void ScrollDown()
        {
            Scroll(ScrollAmount.SmallIncrement);
        }

        public virtual void ScrollUpLarge()
        {
            Scroll(ScrollAmount.LargeDecrement);
        }

        public virtual void ScrollDownLarge()
        {
            Scroll(ScrollAmount.LargeIncrement);
        }

        public virtual bool IsScrollable
        {
            get { return ScrollPattern.Current.VerticallyScrollable; }
        }

        public virtual bool IsNotMinimum
        {
            get { return Value > 0; }
        }

        public override void SetToMinimum()
        {
            ScrollPattern.SetScrollPercent(ScrollPattern.Current.HorizontalScrollPercent, 0);
        }

        public override void SetToMaximum()
        {
            ScrollPattern.SetScrollPercent(ScrollPattern.Current.HorizontalScrollPercent, 100);
        }

        protected virtual void Scroll(ScrollAmount amount)
        {
            if (!IsScrollable) return;
            ScrollPattern.ScrollVertical(amount);
            actionListener.ActionPerformed(Action.Scroll);
        }
    }
}
