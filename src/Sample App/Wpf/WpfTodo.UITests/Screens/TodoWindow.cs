using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Core;
using White.Core;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UIItems.ListBoxItems;
using White.Core.UIItems.WindowItems;
using White.Core.UIItems.WPFUIItems;

namespace WpfTodo.UITests.Screens
{
    public class TodoWindow : Screen
    {
        public TodoWindow(Application application, Window whiteWindow) : base(application, whiteWindow)
        { }

        public IEnumerable<TodoItem> Tasks
        {
            get
            {
                WaitWhileBusy();
                var tasks = WhiteWindow.Get<ListBox>("TasksList");
                return from ListItem item in tasks.Items
                       select new TodoItem
                       {
                           Title = item.Get<Label>(SearchCriteria.ByAutomationId("Title")).Text,
                           Description = item.Get<Label>(SearchCriteria.ByAutomationId("Description")).Text,
                           DueDate = DateTime.Parse(item.Get<Label>(SearchCriteria.ByAutomationId("DueDate")).Text)
                       };
            }
        }

        public NewTaskScreen NewTask()
        {
            var addTaskButton = WhiteWindow.Get<Button>("AddTaskButton");
            addTaskButton.Click();

            return new NewTaskScreen(Application, WhiteWindow.ModalWindow("New Task"));
        }
    }
}