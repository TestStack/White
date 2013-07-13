using System.Windows;
using System.Windows.Input;

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

        private void TextBox_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            DragDrop.DoDragDrop(TextBox, "Foo", DragDropEffects.Move);
            e.Handled = true;
        }
    }
}
