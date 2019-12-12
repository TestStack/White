// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindowViewModel.cs" company="TestStack">
//   All rights reserved.
// </copyright>
// <summary>
//   Defines the MainWindowViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace WpfTodo
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;

    using Todo.Core;

    /// <summary>
    ///     The main window view model.
    /// </summary>
    public class MainWindowViewModel : NotifyPropertyChanged
    {
        /// <summary>
        ///     The repo.
        /// </summary>
        private readonly ITaskRepository repo = new InMemoryTaskRepository();

        /// <summary>
        ///     Initializes a new instance of the <see cref="MainWindowViewModel" /> class.
        /// </summary>
        public MainWindowViewModel()
        {
            this.AddTaskCommand = new DelegateCommand(this.AddNewTask);
            this.Tasks = new ObservableCollection<TodoItem>();
        }

        /// <summary>
        ///     Gets the add task command.
        /// </summary>
        public ICommand AddTaskCommand { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether loading tasks.
        /// </summary>
        public bool LoadingTasks { get; private set; }

        /// <summary>
        ///     Gets or sets the owner.
        /// </summary>
        public Window Owner { get; set; }

        /// <summary>
        ///     Gets the tasks.
        /// </summary>
        public ObservableCollection<TodoItem> Tasks { get; }

        /// <summary>
        ///     The add new task.
        /// </summary>
        private void AddNewTask()
        {
            // By setting Owner it maintains the UI Automation tree, normally this would be done by a service so the VM doesnt reference the view
            var dialog = new NewTaskWindow(this.repo) { Owner = this.Owner };

            if (dialog.ShowDialog() != true)
            {
                return;
            }

            this.Refresh();
        }

        /// <summary>
        ///     The refresh.
        /// </summary>
        private void Refresh()
        {
            this.Tasks.Clear();
            this.LoadingTasks = true;
            this.repo.GetAll().ContinueWith(
                t =>
                    {
                        foreach (var task in t.Result.OrderBy(o => o.DueDate))
                        {
                            Tasks.Add(task);
                        }

                        LoadingTasks = false;
                    }, 
                TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}