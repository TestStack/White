using System.Windows.Automation;

namespace TestStack.White.UIItems.Scrolling
{
    public abstract class WpfTreeViewScrollBar : WpfScrollBar
    {
        protected WpfTreeViewScrollBar(AutomationElement parent) : base(parent)
        {
        }

        protected virtual double ValidPercentage(double percentage)
        {
            if (percentage < 0)
                return 0;
            if (percentage > 100)
                return 100;
            return percentage;
        }

        protected virtual double SmallPercentage()
        {
            return ScrollPercentage / 4;
        }
    }
}