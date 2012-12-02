using System.Collections.Generic;
using System.Windows;
using System.Windows.Automation;
using White.Core.UIItems;

namespace White.Core.Finder
{
    public class AutomationElementPositionComparer : PositionBasedComparer, IComparer<AutomationElement>
    {
        public virtual int Compare(AutomationElement x, AutomationElement y)
        {
            Rect rectX = x.Current.BoundingRectangle;
            Rect rectY = y.Current.BoundingRectangle;
            return Compare(rectX, rectY);
        }
    }

    public class UIItemPositionComparer : PositionBasedComparer, IComparer<IUIItem>
    {
        public virtual int Compare(IUIItem x, IUIItem y)
        {
            return Compare(x.Bounds, y.Bounds);
        }
    }

    public class PositionBasedComparer
    {
        protected static int Compare(Rect rectX, Rect rectY)
        {
            if (rectX.Top.Equals(rectY.Top)) return rectX.Left.CompareTo(rectY.Left);
            return rectX.Top.CompareTo(rectY.Top);
        }
    }
}