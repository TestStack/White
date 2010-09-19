using System.Windows.Forms;

namespace Recorder
{
    public class RecorderForm
    {
        public static void ShowDialog(UserControl userControl, string title)
        {
            Form form = new Form();
            form.Controls.Add(userControl);
            form.Width = userControl.Width + 10;
            form.Height = userControl.Height + 20;
            form.ShowDialog();
        }
    }
}