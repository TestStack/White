using System;
using System.Collections.Generic;
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

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindowEnabled(IntPtr hWnd);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool PostMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        private const uint WM_CLOSE = 0x0010;

        public static IEnumerable<NativeWindow> GetProcessWindows(int processId)
        {
            var result = new List<NativeWindow>();
            Func<IntPtr, bool> processWindow = hwnd =>
            {
                if (IsWindowEnabled(hwnd))
                {
                    int pid;
                    GetWindowThreadProcessId(hwnd, out pid);
                    if (pid == processId)
                        result.Add(new NativeWindow(hwnd));
                }
                return true;
            };
            EnumWindows((wnd, param) => processWindow(wnd), IntPtr.Zero);
            return result;
        }

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
        
        public virtual void PostCloseMessage()
        {
            PostMessage(handle, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
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