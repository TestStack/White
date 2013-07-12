using System.Windows.Automation;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.UIItems.Scrolling
{
    [PlatformSpecificItem(ReferAsType = typeof (IHScrollBar))]
    public class HScrollBar : ScrollBar, IHScrollBar
    {
        protected HScrollBar() {}

        public HScrollBar(AutomationElement automationElement, ActionListener actionListener, ScrollBarButtonAutomationIds automationIds) : base(automationElement, actionListener, automationIds) {}

        public virtual void ScrollLeft()
        {
            BackSmallChangeButton.PerformClick();
        }

        public virtual void ScrollRight()
        {
            ForwardSmallChangeButton.PerformClick();
        }

        public virtual void ScrollLeftLarge()
        {
            BackLargeChangeButton.PerformClick();
        }

        public virtual void ScrollRightLarge()
        {
            ForwardLargeChangeButton.PerformClick();
        }

        public virtual bool IsScrollable
        {
            get { return BackSmallChangeButton != null; }
        }
    }
}