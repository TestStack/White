using System;
using System.Runtime.InteropServices;
using System.Windows;

namespace TestStack.White.WindowsAPI
{
    public class NativeWindow
    {
        private readonly IntPtr handle;

        [DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(POINT point);

        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("gdi32.dll")]
        private static extern COLORREF GetBkColor(IntPtr hdc);

        [DllImport("gdi32.dll")]
        private static extern COLORREF GetTextColor(IntPtr hdc);

        public NativeWindow(Point point)
        {
            handle = WindowFromPoint(new POINT((int) point.X, (int) point.Y));
        }

        public NativeWindow(IntPtr handle)
        {
            this.handle = handle;
        }

        public virtual COLORREF BackgroundColor
        {
            get
            {
                return GetBkColor(GetDC(handle));
            }
        }

        public virtual COLORREF TextColor
        {
            get
            {
                return GetTextColor(GetDC(handle));
            }
        }

        //Native methods needed for highlighting UIItems
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        internal static extern bool SetWindowPos(IntPtr hWnd, IntPtr hwndAfter, int x, int y, int width, int height, int flags);
        [return: MarshalAs(UnmanagedType.Bool)]

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
    }
}
