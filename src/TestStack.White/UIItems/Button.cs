using System.Windows.Automation;
using White.Core.Recording;
using White.Core.UIItems.Actions;

namespace White.Core.UIItems
{
    //TODO Implement standard controls library like OpenDialog
    public class Button : UIItem
    {
        private readonly ToggleableItem toggleableItem;
        protected Button() { }
        public Button(AutomationElement automationElement, ActionListener actionListener)
            : base(automationElement, actionListener)
        {
            toggleableItem = new ToggleableItem(this);
        }

        public override void HookEvents(UIItemEventListener eventListener)
        {
            HookClickEvent(eventListener);
        }

        public override void UnHookEvents()
        {
            UnHookClickEvent();
        }

        public virtual ToggleState State
        {
            get { return toggleableItem.State; }
            set { toggleableItem.State = value; }
        }

        public virtual string Text
        {
            get { return Name; }
        }

        public virtual void Toggle()
        {
            toggleableItem.Toggle();
        }
    }
}