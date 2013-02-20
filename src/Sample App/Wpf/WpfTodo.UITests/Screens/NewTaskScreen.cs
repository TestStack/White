using System;
using System.Windows.Automation;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UIItems.WindowItems;
using White.Repository;

namespace WpfTodo.UITests.Screens
{
    public class NewTaskScreen : Screen
    {
        protected Button CreateButton;

        public NewTaskScreen(Window window, ScreenRepository screenRepository) : base(window, screenRepository)
        {
        }

        public virtual string Title
        {
            get { return window.Get<TextBox>("Title").Text; }
            set { window.Get<TextBox>("Title").Text = value; }
        }

        public virtual string Description
        {
            get { return window.Get<TextBox>("Description").Text; }
            set { window.Get<TextBox>("Description").Text = value; }
        }

        public virtual DateTime DueDate
        {
            get
            {
                var uiItem = window.Get(SearchCriteria.ByAutomationId("DueDate"));
                var currentPropertyValue = uiItem.AutomationElement.GetCurrentPropertyValue(ValuePattern.ValueProperty);
                return (DateTime)currentPropertyValue;
            }
            set
            {
                var uiItem = window.Get(SearchCriteria.ByAutomationId("DueDate"));
                uiItem.Enter(value.ToShortDateString());
            }
        }

        public virtual void Create()
        {
            CreateButton.Click();
            WaitWhileBusy();
        }
    }
}