using System.Windows;
using System.Windows.Automation;
using White.Core.UIItems.Actions;

namespace White.Core.UIItems.Scrolling
{
    [PlatformSpecificItem(ReferAsType = typeof (IVScrollBar))]
    public class WPFVScrollBar : WPFScrollBar, IVScrollBar
    {
        private readonly ActionListener actionListener;

        public WPFVScrollBar(AutomationElement parent, ActionListener actionListener) : base(parent)
        {
            this.actionListener = actionListener;
        }

        protected override double ScrollPercentage
        {
            get { return scrollPattern.Current.VerticalViewSize; }
        }

        public override double Value
        {
            get { return scrollPattern.Current.VerticalScrollPercent; }
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
            get { return scrollPattern.Current.VerticallyScrollable; }
        }

        public virtual bool IsNotMinimum
        {
            get { return Value > 0; }
        }

        public override void SetToMinimum()
        {
            SetToMinimum(ScrollUpLarge);
        }

        public override void SetToMaximum()
        {
            SetToMaximum(ScrollDownLarge);
        }

        protected virtual void Scroll(ScrollAmount amount)
        {
            if (!IsScrollable) return;
            scrollPattern.ScrollVertical(amount);
            actionListener.ActionPerformed(Action.Scroll);
        }
    }
}
