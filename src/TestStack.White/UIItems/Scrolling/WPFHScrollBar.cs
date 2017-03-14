using System.Windows;
using System.Windows.Automation;
using TestStack.White.UIItems.Actions;
using Action = TestStack.White.UIItems.Actions.Action;

namespace TestStack.White.UIItems.Scrolling
{
    [PlatformSpecificItem(ReferAsType = typeof (IHScrollBar))]
    public class WpfHScrollBar : WpfScrollBar, IHScrollBar
    {
        private readonly IActionListener actionListener;

        public WpfHScrollBar(AutomationElement parent, IActionListener actionListener) : base(parent)
        {
            this.actionListener = actionListener;
        }

        public override double Value
        {
            get { return ScrollPattern.Current.HorizontalScrollPercent; }
        }

        protected override double ScrollPercentage
        {
            get { return ScrollPattern.Current.HorizontalViewSize; }
        }

        public override Rect Bounds
        {
            get { return Rect.Empty; }
        }

        protected virtual void Scroll(ScrollAmount amount)
        {
            if (!IsScrollable) return;
            ScrollPattern.ScrollHorizontal(amount);
            actionListener.ActionPerformed(Action.WindowMessage);
        }

        public virtual void ScrollLeft()
        {
            Scroll(ScrollAmount.SmallDecrement);
        }

        public virtual void ScrollRight()
        {
            Scroll(ScrollAmount.SmallIncrement);
        }

        public virtual void ScrollLeftLarge()
        {
            Scroll(ScrollAmount.LargeDecrement);
        }

        public virtual void ScrollRightLarge()
        {
            Scroll(ScrollAmount.LargeIncrement);
        }

        public virtual bool IsScrollable
        {
            get { return ScrollPattern.Current.HorizontallyScrollable; }
        }

        public virtual bool IsNotMinimum
        {
            get { return Value > 0; }
        }

        public override void SetToMinimum()
        {
            ScrollPattern.SetScrollPercent(0, ScrollPattern.Current.VerticalScrollPercent);
        }

        public override void SetToMaximum()
        {
            ScrollPattern.SetScrollPercent(100, ScrollPattern.Current.VerticalScrollPercent);
        }
    }
}
