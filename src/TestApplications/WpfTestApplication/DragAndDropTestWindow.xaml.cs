using System.Windows;

namespace WpfTestApplication
{
    public partial class DragAndDropTestWindow
    {
        public DragAndDropTestWindow()
        {
            InitializeComponent();
        }

        private void ButtonOnDrop(object sender, DragEventArgs e)
        {
            DragDropResults.Content = "TextBoxDraggedOntoButton";            
        }
    }
}
