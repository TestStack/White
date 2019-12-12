// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="TestStack">
//   All rights reserved.
// </copyright>
// <summary>
//   Defines the MainWindow type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace WpfTodo
{
    /// <summary>
    ///     The main window.
    /// </summary>
    public partial class MainWindow
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        public MainWindow()
        {
            DataContext = new MainWindowViewModel { Owner = this };
            InitializeComponent();
        }
    }
}