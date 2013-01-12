using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Todo.Core;

namespace WpfTodo
{
    public class NewTaskViewModel : NotifyPropertyChanged
    {
        private readonly ITaskRepository taskRepository;

        public NewTaskViewModel(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
            CreateTaskCommand = new DelegateCommand(CreateTask, () => !Saving);
            CancelCommand = new DelegateCommand(()=>
                                                    {
                                                        Owner.DialogResult = false;
                                                        Owner.Close();
                                                    }, ()=>!Saving);
            TodoItem = new TodoItem();
        }

        private void CreateTask()
        {
            Saving = true;
            taskRepository.Add(TodoItem)
                .ContinueWith(t =>
                {
                    Saving = false;
                    Owner.DialogResult = true;
                    Owner.Close();
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public TodoItem TodoItem { get; private set; }

        public Window Owner { get; set; }

        public ICommand CreateTaskCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        public bool Saving { get; private set; }
    }
}