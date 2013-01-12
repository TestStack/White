using Todo.Core;

namespace WpfTodo
{
    public partial class NewTaskWindow
    {
        private readonly NewTaskViewModel newTaskViewModel;

        public NewTaskWindow(ITaskRepository taskRepository)
        {
            newTaskViewModel = new NewTaskViewModel(taskRepository) {Owner = this};
            DataContext = newTaskViewModel;
            InitializeComponent();
        }

        public TodoItem TodoItem
        {
            get { return newTaskViewModel.TodoItem; }
        }
    }
}
