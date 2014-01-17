using System;
using System.Runtime.InteropServices;
using System.Threading;
using TestStack.White.WindowsAPI;

namespace TestStack.White.InputDevices
{
    static class Native
    {
        [DllImport("user32", EntryPoint = "SendInput")]
        internal static extern int SendInput(uint numberOfInputs, ref Input input, int structSize);

        [DllImport("user32", EntryPoint = "SendInput")]
        private static extern int SendInput64(int numberOfInputs, ref Input64 input, int structSize);

        [DllImport("user32.dll")]
        internal static extern IntPtr GetMessageExtraInfo();

        [DllImport("user32.dll")]
        internal static extern bool GetCursorPos(ref System.Drawing.Point cursorInfo);

        [DllImport("user32.dll")]
        internal static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        internal static extern bool GetCursorInfo(ref CursorInfo cursorInfo);

        [DllImport("user32.dll")]
        internal static extern short GetDoubleClickTime();

        [DllImport("user32.dll")]
        internal static extern int GetSystemMetrics(SystemMetric smIndex);

        [DllImport("user32.dll")]
        internal static extern short VkKeyScan(char ch);

        [DllImport("user32.dll")]
        internal static extern ushort GetKeyState(uint virtKey);
        
        internal static void SendInput(Input input)
        {
            // Added check for 32/64 bit  
            if (IntPtr.Size == 4)
                SendInput(1, ref input, Marshal.SizeOf(typeof (Input)));
            else
            {
                var input64 = new Input64(input);
                SendInput64(1, ref input64, Marshal.SizeOf(typeof (Input)));
            }
        }
    }
}