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
            if (Checked) return;
            Select(!Checked);
            if (Checked) return;
            Select(!Checked);
        }

        public override void UnCheck()
        {
            if (!Checked) return;
            Select(Checked);
            if (!Checked) return;
            Select(Checked);
        }

        public override bool Checked
        {
            get
            {
                var toggleState = (ToggleState) Property(TogglePattern.ToggleStateProperty);
                return toggleState.Equals(ToggleState.On);
            }
        }
    }
}