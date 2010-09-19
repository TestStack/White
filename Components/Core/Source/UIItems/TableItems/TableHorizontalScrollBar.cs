using System;
using System.Windows;
using System.Windows.Automation;
using White.Core.UIItems.Actions;
using White.Core.UIItems.Scrolling;

namespace White.Core.UIItems.TableItems
{
    public class TableHorizontalScrollBar : IHScrollBar
    {
        protected TableHorizontalScrollBar() {}

        public TableHorizontalScrollBar(AutomationElement automationElement, ActionListener actionListener) {}

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
