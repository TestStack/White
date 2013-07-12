using System;
using System.Collections.Generic;
using System.Linq;
using TestStack.White.Repository;
using Todo.Core;
using White.Core.Factory;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UIItems.ListBoxItems;
using White.Core.UIItems.WPFUIItems;
using White.Core.UIItems.WindowItems;

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