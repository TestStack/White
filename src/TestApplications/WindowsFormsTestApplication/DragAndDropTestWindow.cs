using System.Windows.Forms;

namespace WindowsFormsTestApplication
{
    public partial class DragAndDropTestWindow : Form
    {
        public DragAndDropTestWindow()
        {
            InitializeComponent();
        }

        private void Button_DragDrop(object sender, DragEventArgs e)
        {
            DragDropResults.Text = "TextBoxDraggedOntoButton";            
        }
    }
}
