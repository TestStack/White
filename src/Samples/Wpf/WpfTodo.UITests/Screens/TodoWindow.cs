// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TodoWindow.cs" company="TestStack">
//   All rights reserved.
// </copyright>
// <summary>
//   Defines the TodoWindow type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WpfTodo.UITests.Screens
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using TestStack.White.Factory;
    using TestStack.White.ScreenObjects;
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.Finders;
    using TestStack.White.UIItems.ListBoxItems;
    using TestStack.White.UIItems.WindowItems;
    using TestStack.White.UIItems.WPFUIItems;

    using Todo.Core;

    /// <summary>
    /// The to-do window.
    /// </summary>
    public class TodoWindow : Screen
    {
        /// <summary>
        /// The tasks list.
        /// </summary>
        private readonly ListBox tasksList = null;

        /// <summary>
        /// The add task button.
        /// </summary>
        private readonly Button addTaskButton = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoWindow"/> class.
        /// </summary>
        /// <param name="window">
        /// The window.
        /// </param>
        /// <param name="screenRepository">
        /// The screen repository.
        /// </param>
        public TodoWindow(Window window, ScreenRepository screenRepository) : base(window, screenRepository)
        {
        }

        /// <summary>
        /// Gets the tasks.
        /// </summary>
        public virtual IEnumerable<TodoItem> Tasks
        {
            get
            {
                this.WaitWhileBusy();
                return from ListItem item in this.tasksList.Items
                       select new TodoItem
                       {
                           Title = item.Get<Label>(SearchCriteria.ByAutomationId("Title")).Text,
                           Description = item.Get<Label>(SearchCriteria.ByAutomationId("Description")).Text,
                           DueDate = DateTime.Parse(item.Get<Label>(SearchCriteria.ByAutomationId("DueDate")).Text)
                       };
            }
        }

        /// <summary>
        /// The new task.
        /// </summary>
        /// <returns>
        /// The <see cref="NewTaskScreen"/>.
        /// </returns>
        public virtual NewTaskScreen NewTask()
        {
            this.addTaskButton.Click();

            return ScreenRepository.GetModal<NewTaskScreen>("New Task", this.Window, InitializeOption.NoCache);
        }
    }
}