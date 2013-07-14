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
            BackSmallChangeButton.Click();
        }

        public virtual void ScrollRight()
        {
            ForwardSmallChangeButton.Click();
        }

        public virtual void ScrollLeftLarge()
        {
            BackLargeChangeButton.Click();
        }

        public virtual void ScrollRightLarge()
        {
            ForwardLargeChangeButton.Click();
        }

        public virtual bool IsScrollable
        {
            get { return BackSmallChangeButton != null; }
        }
    }
}