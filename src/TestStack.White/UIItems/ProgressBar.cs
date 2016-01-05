using System.Windows.Automation;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.UIItems
{
    public class ProgressBar : UIItem
    {
        protected ProgressBar() {}
        public ProgressBar(AutomationElement automationElement, IActionListener actionListener) : base(automationElement, actionListener) {}

        public virtual double Minimum
        {
            get { return (double) Property(RangeValuePattern.MinimumProperty); }
        }

        public virtual double Maximum
        {
            get { return (double) Property(RangeValuePattern.MaximumProperty); }
        }

        public virtual double Value
        {
            get { return (double) Property(RangeValuePattern.ValueProperty); }
        }
    }
}