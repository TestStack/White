using System.Windows;
using System.Windows.Automation;
using TestStack.White.Recording;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.UIItems
{
    public class Hyperlink : UIItem
    {
        protected Hyperlink() {}
        public Hyperlink(AutomationElement automationElement, IActionListener actionListener) : base(automationElement, actionListener) {}

        public virtual void Click(int xOffset, int yOffset)
        {
            var x = automationElement.Current.BoundingRectangle.X + xOffset;
            var y = automationElement.Current.BoundingRectangle.Y + yOffset;
            mouse.LeftClick(new Point((int) x, (int) y), actionListener);
        }

        public override void HookEvents(IUIItemEventListener eventListener)
        {
            HookClickEvent(eventListener);
        }

        public override void UnHookEvents()
        {
            UnHookClickEvent();
        }
    }
}