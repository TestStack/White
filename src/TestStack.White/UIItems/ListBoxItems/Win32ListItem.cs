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
                Toggle();
                if (Checked == value) return;
                Toggle();
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
                var toggleState = (ToggleState) Property(TogglePattern.ToggleStateProperty);
                return toggleState.Equals(ToggleState.On);
            }
        }

        private void Toggle()
        {
            ((TogglePattern)Pattern(TogglePattern.Pattern)).Toggle();
        }
    }
}