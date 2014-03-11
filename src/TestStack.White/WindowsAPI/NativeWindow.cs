using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using TestStack.White.Utility;

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

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        public static bool WaitForInputIdle(IntPtr hWnd, TimeSpan timeout)
        {
            int pid;
            uint tid = GetWindowThreadProcessId(hWnd, out pid);
            if (tid == 0) return true; // probably closed already
            return Retry.For(() => IsThreadIdle(pid, tid), timeout, TimeSpan.FromMilliseconds(10));
        }

        private static bool IsThreadIdle(int pid, uint tid)
        {
            Process prc;
            try
            {
                prc = Process.GetProcessById(pid);
            }
            catch (ArgumentException)
            {
                // process with specified pid is not running - most probably it was closed already, in which case we can assume it is definitely idle
                return true;
            }
            var thr = prc.Threads.Cast<ProcessThread>().First(t => tid == t.Id);
            return thr.ThreadState == ThreadState.Wait &&
                   thr.WaitReason == ThreadWaitReason.UserRequest;
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

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
    }
}