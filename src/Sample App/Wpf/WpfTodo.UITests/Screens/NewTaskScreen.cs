using System;
using System.Windows.Automation;
using White.Core;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UIItems.WindowItems;

namespace WpfTodo.UITests.Screens
{
    public class NewTaskScreen : Screen
    {
        public NewTaskScreen(Application application, Window whiteWindow) : base(application, whiteWindow)
        {
        }

        public string Title
        {
            get { return WhiteWindow.Get<TextBox>("Title").Text; }
            set { WhiteWindow.Get<TextBox>("Title").Text = value; }
        }

        public string Description
        {
            get { return WhiteWindow.Get<TextBox>("Description").Text; }
            set { WhiteWindow.Get<TextBox>("Description").Text = value; }
        }

        public DateTime DueDate
        {
            get
            {
                var uiItem = WhiteWindow.Get(SearchCriteria.ByAutomationId("DueDate"));
                var currentPropertyValue = uiItem.AutomationElement.GetCurrentPropertyValue(ValuePattern.ValueProperty);
                return (DateTime)currentPropertyValue;
            }
            set
            {
                var uiItem = WhiteWindow.Get(SearchCriteria.ByAutomationId("DueDate"));
                uiItem.Enter(value.ToShortDateString());
            }
        }

        public void Create()
        {
            WhiteWindow.Get<Button>("CreateButton").Click();
            WaitWhileBusy();
        }
    }
}