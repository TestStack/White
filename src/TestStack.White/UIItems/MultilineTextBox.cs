using System.Windows.Automation;
using White.Core.Recording;
using White.Core.UIItemEvents;
using White.Core.UIItems.Actions;
using White.Core.WindowsAPI;

namespace White.Core.UIItems
{
    public class MultilineTextBox : TextBox, Scrollable
    {
        private AutomationEventHandler handler;
        protected MultilineTextBox() {}
        public MultilineTextBox(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}

        public override string Text
        {
            get
            {
                var pattern = (TextPattern) Pattern(TextPattern.Pattern);
                return pattern.DocumentRange.GetText(int.MaxValue);
            }
            set
            {
                var pattern = (TextPattern) Pattern(TextPattern.Pattern);
                pattern.DocumentRange.Select();
                ActionPerformed();
                keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.DELETE, ActionListener);
                ActionPerformed();
                EnterData(value);
            }
        }

        public override void HookEvents(UIItemEventListener eventListener)
        {
            handler = delegate { eventListener.EventOccured(new MultilineTextBoxEvent(this)); };
            Automation.AddAutomationEventHandler(TextPattern.TextSelectionChangedEvent, automationElement, TreeScope.Element, handler);
        }

        public override void UnHookEvents()
        {
            Automation.RemoveAutomationEventHandler(TextPattern.TextSelectionChangedEvent, automationElement, handler);
        }
    }
}