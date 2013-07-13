using System.Windows.Forms;

namespace WindowsFormsTestApplication.Scenarios
{
    public partial class DragAndDropTestWindow : Form
    {
        public DragAndDropTestWindow()
        {
            InitializeComponent();
        }

        private void TextBox_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox.DoDragDrop("Foo", DragDropEffects.Move);
        }

        private void Button_DragEnter(object sender, DragEventArgs e)
        {
            DragDropResults.Text = "TextBoxDraggedOntoButton";
        }
    }
}
