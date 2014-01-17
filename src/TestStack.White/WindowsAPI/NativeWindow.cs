using System;
using System.Diagnostics;
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
            Process prc = Process.GetProcessById(pid);
            var thr = prc.Threads.Cast<ProcessThread>().First(t => tid == t.Id);
            return thr.ThreadState == ThreadState.Wait &&
                   thr.WaitReason == ThreadWaitReason.UserRequest;
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
    }
}
