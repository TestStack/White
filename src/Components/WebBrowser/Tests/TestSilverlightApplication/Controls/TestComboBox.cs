using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace TestSilverlightApplication.Controls
{
    public class TestComboBox : ComboBox
    {
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            CursorManager.WaitAndPerform(this, () => base.OnMouseLeftButtonDown(e));
        }

        protected override void OnDropDownClosed(EventArgs e)
        {
            CursorManager.WaitAndPerform(this, () => base.OnDropDownClosed(e));
        }

        protected override void OnDropDownOpened(EventArgs e)
        {
            CursorManager.WaitAndPerform(this, () => base.OnDropDownOpened(e));
        }
    }
}