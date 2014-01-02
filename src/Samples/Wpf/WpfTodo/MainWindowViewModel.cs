using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Todo.Core;

namespace WpfTodo
{
    public class MainWindowViewModel : NotifyPropertyChanged
    {
        private readonly ITaskRepository repo = new InMemoryTaskRepository();

        public MainWindowViewModel()
        {
            AddTaskCommand = new DelegateCommand(AddNewTask);
            Tasks = new ObservableCollection<TodoItem>();
        }

        public Window Owner { get; set; }

        private void AddNewTask()
        {
            //By setting Owner it maintains the UI Automation tree, normally this would be done by a service so the VM doesnt reference the view
            var dialog = new NewTaskWindow(repo) { Owner = Owner };

            if (dialog.ShowDialog() != true) return;

            Refresh();
        }

        private void Refresh()
        {
            Tasks.Clear();
            LoadingTasks = true;
            repo.GetAll().ContinueWith(t =>
            {
                foreach (var task in t.Result.OrderBy(o => o.DueDate))
                {
                    Tasks.Add(task);
                }
                LoadingTasks = false;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public ObservableCollection<TodoItem> Tasks { get; private set; }

        public ICommand AddTaskCommand { get; private set; }

        public bool LoadingTasks { get; private set; }
    }
}