using System.Windows;
using System.Windows.Input;

namespace TestSilverlightApplication
{
    public static class CursorManager
    {
        public delegate void Do();

        public static void WaitAndPerform(FrameworkElement frameworkElement, Do @do)
        {
            frameworkElement.Cursor = Cursors.Wait;
            try
            {
                @do();
            }
            finally
            {
                frameworkElement.Cursor = Cursors.Arrow;
            }
        }
    }
}