using System;
using System.Windows.Automation;
using TestStack.White.ScreenObjects;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

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
            get { return Window.Get<TextBox>("Title").Text; }
            set { Window.Get<TextBox>("Title").Text = value; }
        }

        public virtual string Description
        {
            get { return Window.Get<TextBox>("Description").Text; }
            set { Window.Get<TextBox>("Description").Text = value; }
        }

        public virtual DateTime DueDate
        {
            get
            {
                var uiItem = Window.Get(SearchCriteria.ByAutomationId("DueDate"));
                var currentPropertyValue = uiItem.AutomationElement.GetCurrentPropertyValue(ValuePattern.ValueProperty);
                return (DateTime)currentPropertyValue;
            }
            set
            {
                var uiItem = Window.Get(SearchCriteria.ByAutomationId("DueDate"));
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