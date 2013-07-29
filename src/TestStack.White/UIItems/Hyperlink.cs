using System.Windows;
using System.Windows.Automation;
using TestStack.White.Recording;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.UIItems
{
    public class Hyperlink : UIItem
    {
        protected Hyperlink() {}
        public Hyperlink(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}

        public virtual void Click(int xOffset, int yOffset)
        {
            double x = automationElement.Current.BoundingRectangle.X + xOffset;
            double y = automationElement.Current.BoundingRectangle.Y + yOffset;
            mouse.Click(new Point((int) x, (int) y), ActionListener);
        }

        public override void HookEvents(UIItemEventListener eventListener)
        {
            HookClickEvent(eventListener);
        }

        public override void UnHookEvents()
        {
            UnHookClickEvent();
        }
    }
}