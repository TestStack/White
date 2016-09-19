using System;
using System.Runtime.InteropServices;
using TestStack.White.WindowsAPI;

namespace TestStack.White.InputDevices
{
    internal static class MouseWin32
    {
        [DllImport("user32", EntryPoint = "SendInput")]
        private static extern int SendInput(uint numberOfInputs, ref Input input, int structSize);

        [DllImport("user32", EntryPoint = "SendInput")]
        private static extern int SendInput64(int numberOfInputs, ref Input64 input, int structSize);

        [DllImport("user32.dll")]
        private static extern IntPtr GetMessageExtraInfo();

        [DllImport("user32.dll")]
        internal static extern bool GetCursorPos(ref System.Drawing.Point cursorInfo);

        [DllImport("user32.dll")]
        internal static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        internal static extern bool GetCursorInfo(ref CursorInfo cursorInfo);

        [DllImport("user32.dll")]
        internal static extern short GetDoubleClickTime();

        [DllImport("user32.dll")]
        private static extern int GetSystemMetrics(SystemMetric smIndex);

        private static int RightMouseButtonDown
        {
            get { return GetSystemMetrics(SystemMetric.SM_SWAPBUTTON) == 0 ? WindowsConstants.MOUSEEVENTF_RIGHTDOWN : WindowsConstants.MOUSEEVENTF_LEFTDOWN; }
        }

        private static int RightMouseButtonUp
        {
            get { return GetSystemMetrics(SystemMetric.SM_SWAPBUTTON) == 0 ? WindowsConstants.MOUSEEVENTF_RIGHTUP : WindowsConstants.MOUSEEVENTF_LEFTUP; }
        }

        private static int LeftMouseButtonDown
        {
            get { return GetSystemMetrics(SystemMetric.SM_SWAPBUTTON) == 0 ? WindowsConstants.MOUSEEVENTF_LEFTDOWN : WindowsConstants.MOUSEEVENTF_RIGHTDOWN; }
        }

        private static int LeftMouseButtonUp
        {
            get { return GetSystemMetrics(SystemMetric.SM_SWAPBUTTON) == 0 ? WindowsConstants.MOUSEEVENTF_LEFTUP : WindowsConstants.MOUSEEVENTF_RIGHTUP; }
        }

        /// <summary>
        /// Performs a down / up sequence for the specified button
        /// </summary>
        internal static void MouseButtonUpAndDown(MouseButton mouseButton)
        {
            MouseButtonDown(mouseButton);
            MouseButtonUp(mouseButton);
        }

        /// <summary>
        /// Performs a down for the specified button
        /// </summary>
        internal static void MouseButtonDown(MouseButton mouseButton)
        {
            SendInput(InputFactory.Mouse(GetInputForButton(mouseButton, true)));
        }

        /// <summary>
        /// Performs an up for the specified button
        /// </summary>
        internal static void MouseButtonUp(MouseButton mouseButton)
        {
            SendInput(InputFactory.Mouse(GetInputForButton(mouseButton, false)));
        }

        /// <summary>
        /// Generates the input object for the button
        /// </summary>
        /// <param name="mouseButton">The button to get the input for</param>
        /// <param name="isDown">Flag if down is wanted, up otherwise</param>
        private static MouseInput GetInputForButton(MouseButton mouseButton, bool isDown)
        {
            switch (mouseButton)
            {
                case MouseButton.Left:
                    return MouseInput(isDown ? LeftMouseButtonDown : LeftMouseButtonUp);
                case MouseButton.Right:
                    return MouseInput(isDown ? RightMouseButtonDown : RightMouseButtonUp);
                case MouseButton.Middle:
                    return MouseInput(isDown ? WindowsConstants.MOUSEEVENTF_MIDDLEDOWN : WindowsConstants.MOUSEEVENTF_MIDDLEUP);
                case MouseButton.XButton1:
                    return MouseInput(isDown ? WindowsConstants.MOUSEEVENTF_XDOWN : WindowsConstants.MOUSEEVENTF_XUP, 0x0001);
                case MouseButton.XButton2:
                    return MouseInput(isDown ? WindowsConstants.MOUSEEVENTF_XDOWN : WindowsConstants.MOUSEEVENTF_XUP, 0x0002);
                default:
                    throw new ArgumentOutOfRangeException("mouseButton", "Unknown mouse button");
            }
        }

        private static void SendInput(Input input)
        {
            // Added check for 32/64 bit  
            if (IntPtr.Size == 4)
                SendInput(1, ref input, Marshal.SizeOf(typeof(Input)));
            else
            {
                var input64 = new Input64(input);
                SendInput64(1, ref input64, Marshal.SizeOf(typeof(Input)));
            }
        }

        private static MouseInput MouseInput(int command, int mouseData = 0)
        {
            return new MouseInput(command, GetMessageExtraInfo(), mouseData);
        }
    }
}