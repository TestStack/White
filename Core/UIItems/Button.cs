using System.Windows.Automation;
using White.Core.Recording;
using White.Core.UIItems.Actions;

namespace White.Core.UIItems
{
    //TODO Implement standard controls library like OpenDialog
    public class Button : UIItem
    {
        protected Button() {}
        public Button(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}

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