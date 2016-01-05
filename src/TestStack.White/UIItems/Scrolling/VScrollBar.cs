using System.Windows.Automation;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.UIItems.Scrolling
{
    [PlatformSpecificItem(ReferAsType = typeof(IVScrollBar))]
    public class VScrollBar : ScrollBar, IVScrollBar
    {
        protected VScrollBar()
        {         
        }
        public VScrollBar(AutomationElement automationElement, IActionListener actionListener,
            ScrollBarButtonAutomationIds automationIds) : base(automationElement, actionListener, automationIds)
        {
        }

        public virtual void ScrollUp()
        {
            BackSmallChangeButton.Click();
        }

        public virtual void ScrollDown()
        {
            ForwardSmallChangeButton.Click();
        }

        public virtual void ScrollUpLarge()
        {
            BackLargeChangeButton.Click();
        }

        public virtual void ScrollDownLarge()
        {
            ForwardLargeChangeButton.Click();
        }

        public virtual bool IsScrollable
        {
            get { return BackLargeChangeButton != null; }
        }

        public virtual bool IsNotMinimum
        {
            get { return Value > 0; }
        }
    }
}
