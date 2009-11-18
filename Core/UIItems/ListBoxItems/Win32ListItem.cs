using System.Windows.Automation;
using White.Core.UIItems.Actions;

namespace White.Core.UIItems.ListBoxItems
{
    [PlatformSpecificItem]
    public class Win32ListItem : ListItem
    {
        protected Win32ListItem() {}
        public Win32ListItem(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}

        public override void Check()
        {
            DoCheck = true;
        }

        private bool DoCheck
        {
            set
            {
                if (Checked == value) return;
                Select();
                if (Checked == value) return;
                Select();
            }
        }

        public override void UnCheck()
        {
            DoCheck = false;
        }

        public override bool Checked
        {
            get
            {
                ToggleState toggleState = (ToggleState) Property(TogglePattern.ToggleStateProperty);
                return toggleState.Equals(ToggleState.On);
            }
        }
    }
}