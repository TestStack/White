using System;
using System.Collections.Generic;
using System.Linq;
using TestStack.White.Factory;
using TestStack.White.Repository;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.WPFUIItems;
using Todo.Core;

namespace WpfTodo.UITests.Screens
{
    public class TodoWindow : Screen
    {
        protected ListBox TasksList;
        protected Button AddTaskButton;

        public TodoWindow(Window window, ScreenRepository screenRepository) : base(window, screenRepository)
        {
        }

        public virtual IEnumerable<TodoItem> Tasks
        {
            get
            {
                WaitWhileBusy();
                return from ListItem item in TasksList.Items
                       select new TodoItem
                       {
                           Title = item.Get<Label>(SearchCriteria.ByAutomationId("Title")).Text,
                           Description = item.Get<Label>(SearchCriteria.ByAutomationId("Description")).Text,
                           DueDate = DateTime.Parse(item.Get<Label>(SearchCriteria.ByAutomationId("DueDate")).Text)
                       };
            }
        }

        public virtual NewTaskScreen NewTask()
        {
            AddTaskButton.Click();

            return screenRepository.GetModal<NewTaskScreen>("New Task", window, InitializeOption.NoCache);
        }
    }
}