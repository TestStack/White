using System;
using System.Windows.Automation;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Custom;

namespace TestStack.White.UITests.ControlTests
{
    [ControlTypeMapping(CustomUIItemType.Pane)]
    [ControlTypeMapping(CustomUIItemType.Custom, WindowsFramework.Wpf)]
    public class MyDateUIItem : CustomUIItem
    {
        public MyDateUIItem(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) { }

        protected MyDateUIItem() { }

        public virtual void EnterDate(DateTime dateTime)
        {
            Container.Get<TextBox>("Day").Text = dateTime.Day.ToString();
            Container.Get<TextBox>("Month").Text = dateTime.Month.ToString();
            Container.Get<TextBox>("Year").Text = dateTime.Year.ToString();
        }
    }
}