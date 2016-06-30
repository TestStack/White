// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewTaskViewModel.cs" company="TestStack">
//   All rights reserved.
// </copyright>
// <summary>
//   Defines the NewTaskViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WpfTodo
{
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;

    using Todo.Core;

    /// <summary>
    /// The new task view model.
    /// </summary>
    public class NewTaskViewModel : NotifyPropertyChanged
    {
        /// <summary>
        /// The task repository.
        /// </summary>
        private readonly ITaskRepository taskRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="NewTaskViewModel"/> class.
        /// </summary>
        /// <param name="taskRepository">
        /// The task repository.
        /// </param>
        public NewTaskViewModel(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
            this.CreateTaskCommand = new DelegateCommand(this.CreateTask, () => !this.Saving);
            this.CancelCommand = new DelegateCommand(
                () =>
                    {
                        Owner.DialogResult = false;
                        Owner.Close();
                    },
                () => !this.Saving);
            TodoItem = new TodoItem();
        }

        /// <summary>
        /// Gets the to-do item.
        /// </summary>
        public TodoItem TodoItem { get; private set; }

        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        public Window Owner { get; set; }

        /// <summary>
        /// Gets the create task command.
        /// </summary>
        public ICommand CreateTaskCommand { get; private set; }

        /// <summary>
        /// Gets the cancel command.
        /// </summary>
        public ICommand CancelCommand { get; private set; }

        /// <summary>
        /// Gets a value indicating whether saving.
        /// </summary>
        public bool Saving { get; private set; }

        /// <summary>
        /// The create task.
        /// </summary>
        private void CreateTask()
        {
            this.Saving = true;
            this.taskRepository.Add(TodoItem).ContinueWith(
                t =>
                    {
                        Saving = false;
                        Owner.DialogResult = true;
                        Owner.Close();
                    },
                TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}