using System;
using System.Windows.Automation;
using TestStack.White.Configuration;
using TestStack.White.UIItems.Actions;
using TestStack.White.WindowsAPI;

namespace TestStack.White.UIItems
{
    public class DateTimePicker : UIItem
    {
        protected DateTimePicker() {}
        public DateTimePicker(AutomationElement automationElement, IActionListener actionListener) : base(automationElement, actionListener) {}

        public virtual DateTime? Date
        {
            get
            {
                var property = (string) Property(ValuePattern.ValueProperty);

                if (string.IsNullOrEmpty(property))
                    property = (string) Property(LegacyIAccessiblePattern.ValueProperty);

                if (string.IsNullOrEmpty(property))
                    return null;
                return DateTime.Parse(property);
            }
            set
            {
                SetDate(value, CoreConfigurationLocator.Get().DefaultDateFormat);
            }
        }

        public virtual void SetDate(DateTime? dateTime, DateFormat dateFormat)
        {
            if (dateTime == null)
            {
                Logger.Warn("DateTime cannot be null, value will not be set");
                return;
            }

            keyboard.Send(dateFormat.DisplayValue(dateTime.Value, 0).ToString(), actionListener);
            keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.RIGHT, actionListener);
            keyboard.Send(dateFormat.DisplayValue(dateTime.Value, 1).ToString(), actionListener);
            keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.RIGHT, actionListener);
            keyboard.Send(dateFormat.DisplayValue(dateTime.Value, 2).ToString(), actionListener);
            keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.RIGHT, actionListener);
        }
    }
}