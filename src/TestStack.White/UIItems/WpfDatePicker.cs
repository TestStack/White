using System;
using System.Windows.Automation;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.UIItems
{
    [PlatformSpecificItem]
    public class WpfDatePicker : DateTimePicker
    {
        protected WpfDatePicker() {}
        public WpfDatePicker(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) { }

        public override void SetDate(DateTime? dateTime, DateFormat dateFormat)
        {
            GetPattern<ValuePattern>().SetValue(dateTime != null ? dateTime.Value.ToShortDateString() : null);
        }
    }
}