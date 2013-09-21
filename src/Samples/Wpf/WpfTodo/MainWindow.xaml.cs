namespace WpfTodo
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            DataContext = new MainWindowViewModel { Owner = this };
            InitializeComponent();
        }
    }
}
