namespace WindowsFormsTestApplication.Scenarios
{
    using System.Windows.Forms;

    public partial class DragAndDropTestWindow : Form
    {
        public DragAndDropTestWindow()
        {
            InitializeComponent();
        }

        private void Button_DragEnter(object sender, DragEventArgs e)
        {
            DragDropResults.Text = "TextBoxDraggedOntoButton";
        }

        private void TextBox_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox.DoDragDrop("Foo", DragDropEffects.Move);
        }
    }
}