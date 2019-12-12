// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewTaskWindow.xaml.cs" company="TestStack">
//   All rights reserved.
// </copyright>
// <summary>
//   Defines the NewTaskWindow type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace WpfTodo
{
    using Todo.Core;

    /// <summary>
    ///     The new task window.
    /// </summary>
    public partial class NewTaskWindow
    {
        /// <summary>
        ///     The new task view model.
        /// </summary>
        private readonly NewTaskViewModel newTaskViewModel;

        /// <summary>
        ///     Initializes a new instance of the <see cref="NewTaskWindow" /> class.
        /// </summary>
        /// <param name="taskRepository">
        ///     The task repository.
        /// </param>
        public NewTaskWindow(ITaskRepository taskRepository)
        {
            this.newTaskViewModel = new NewTaskViewModel(taskRepository) { Owner = this };
            DataContext = this.newTaskViewModel;
            this.InitializeComponent();
        }

        /// <summary>
        ///     Gets the to-do item.
        /// </summary>
        public TodoItem TodoItem => newTaskViewModel.TodoItem;
    }
}