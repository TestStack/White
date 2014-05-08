using System.Windows.Automation;
using TestStack.White.Recording;
using TestStack.White.UIItemEvents;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.UIItems
{
    public class CheckBox : Button
    {
        private AutomationPropertyChangedEventHandler handler;

        protected CheckBox()
        {
        }

        public CheckBox(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener)
        {
        }

        public virtual void Select()
        {
            Checked = true;
        }

        /// <summary>
        /// true when CheckBox is checked
        /// </summary>
        public virtual bool IsSelected
        {
            get { return Checked; }
        }

        public virtual bool Checked
        {
            get { return State.Equals(ToggleState.On); }
            set
            {
                if (Checked == value) return;
                Click();
            }
        }

        /// <summary>
        /// Unchecks the checkbox
        /// </summary>
        public virtual void UnSelect()
        {
            Checked = false;
        }

        public override void HookEvents(UIItemEventListener eventListener)
        {
            handler = delegate
                          {
                              ActionPerformed();
                              eventListener.EventOccured(new CheckBoxEvent(this));
                          };
            Automation.AddAutomationPropertyChangedEventHandler(automationElement, TreeScope.Element, handler,
                                                                TogglePattern.ToggleStateProperty);
        }

        public override void UnHookEvents()
        {
            Automation.RemoveAutomationPropertyChangedEventHandler(automationElement, handler);
        }

        public override void SetValue(object value)
        {
            if (!(value is bool))
                throw new UIActionException("Cannot set non bool value to a checkbox. Trying to set: " + value);
            Checked = (bool) value;
        }
    }
}