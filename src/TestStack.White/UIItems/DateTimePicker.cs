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
        public DateTimePicker(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}

        public virtual DateTime? Date
        {
            get
            {
                var property = (string) Property(ValuePattern.ValueProperty);
                if (string.IsNullOrEmpty(property))
                    return null;
                return DateTime.Parse(property);
            }
            set
            {
                SetDate(value, CoreAppXmlConfiguration.Instance.DefaultDateFormat);
            }
        }

        private void ClearDate()
        {
            
        }

        public virtual void SetDate(DateTime? dateTime, DateFormat dateFormat)
        {
            if (dateTime == null)
            {
                ClearDate();
                return;
            }

            keyboard.Send(dateFormat.DisplayValue(dateTime.Value, 0).ToString(), ActionListener);
            keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.RIGHT, ActionListener);
            keyboard.Send(dateFormat.DisplayValue(dateTime.Value, 1).ToString(), ActionListener);
            keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.RIGHT, ActionListener);
            keyboard.Send(dateFormat.DisplayValue(dateTime.Value, 2).ToString(), ActionListener);
            keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.RIGHT, ActionListener);
        }
    }
}