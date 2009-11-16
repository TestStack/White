using System;
using System.Threading;
using System.Windows;

namespace WindowsPresentationFramework
{
    /// <summary>
    /// Interaction logic for ModalWindow.xaml
    /// </summary>
    public partial class ModalWindow
    {
        public ModalWindow()
        {
            InitializeComponent();
            Title = "ModalForm";
            ok.Click += OkClicked;
        }

        private void OkClicked(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}