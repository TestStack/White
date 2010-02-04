using System.Windows.Controls;

namespace TestSilverlightApplication.Controls
{
    public class TestButton : Button
    {
        protected override void OnClick()
        {
            CursorManager.WaitAndPerform(this, () => base.OnClick());
        }
    }
}