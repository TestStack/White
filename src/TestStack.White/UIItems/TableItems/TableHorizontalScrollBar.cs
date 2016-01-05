using System;
using System.Windows;
using System.Windows.Automation;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Scrolling;

namespace TestStack.White.UIItems.TableItems
{
    public class TableHorizontalScrollBar : IHScrollBar
    {
        protected TableHorizontalScrollBar() {}

        public TableHorizontalScrollBar(AutomationElement automationElement, IActionListener actionListener) {}

        public virtual void ScrollLeft()
        {
            ;
        }

        public virtual void ScrollRight()
        {
            ;
        }

        public virtual void ScrollLeftLarge()
        {
            ;
        }

        public virtual void ScrollRightLarge()
        {
            ;
        }

        public virtual bool IsScrollable
        {
            get { return false; }
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

        public virtual void SetToMinimum() {}

        public virtual void SetToMaximum() {}

        public virtual Rect Bounds
        {
            get { throw new NotSupportedException(); }
        }
    }
}
