using System.Windows.Automation;
using TestStack.White.UIA;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Scrolling;

namespace TestStack.White.UIItems.TableItems
{
    //TODO Table in scrolled position is not supported
    public class TableVerticalScrollBar : UIItem, IVScrollBar
    {
        private readonly ITableVerticalScrollOffset offset;
        protected TableVerticalScrollBar() {}

        public TableVerticalScrollBar(AutomationElement automationElement, IActionListener actionListener, ITableVerticalScrollOffset offset)
            : base(automationElement, actionListener)
        {
            this.offset = offset;
        }

        public virtual void ScrollUp()
        {
            mouse.LeftClick(Bounds.ImmediateInteriorNorth(), actionListener);
        }

        public virtual void ScrollDown()
        {
            mouse.LeftClick(Bounds.ImmediateInteriorSouth(), actionListener);
        }

        public virtual void ScrollUpLarge()
        {
            ScrollUp();
        }

        public virtual void ScrollDownLarge()
        {
            ScrollDown();
        }

        public virtual bool IsScrollable
        {
            get { return true; }
        }

        public virtual bool IsNotMinimum
        {
            get { return !offset.IsOnTop; }
        }

        public virtual double Value
        {
            get { return 0; }
        }

        public virtual double MinimumValue
        {
            get { return 0; }
        }

        public virtual double MaximumValue
        {
            get { return 100; }
        }

        public virtual void SetToMinimum()
        {
            while (IsNotMinimum)
            {
                ScrollUpLarge();
            }
        }

        public virtual void SetToMaximum() {}
    }
}