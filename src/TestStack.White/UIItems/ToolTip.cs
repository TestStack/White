using System.Windows;
using System.Windows.Automation;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.UIItems
{
    public class ToolTip : UIItem
    {
        protected ToolTip() {}
        public ToolTip(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}

        public virtual string Text
        {
            get { return automationElement.Current.Name; }
        }

        public static ToolTip GetFrom(Point point)
        {
            AutomationElement automationElement = AutomationElement.FromPoint(point);
            return automationElement.Current.ControlType.Equals(ControlType.ToolTip) ? new ToolTip(automationElement, new NullActionListener()) : null;
        }

        public virtual Point LeftOutside(Rect rect)
        {
            return new Point((int) Bounds.Left - 1, (int) rect.Y);
        }
    }
}