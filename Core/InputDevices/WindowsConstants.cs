namespace White.Core.InputDevices
{
    /// <summary>
    /// Constants defined in winuser.h in C:\Program Files\Microsoft Visual Studio 8\VC\PlatformSDK\Include\WinUser.h
    /// </summary>
    public class WindowsConstants
    {
        public const uint SW_HIDE = 0;
        public const uint SW_SHOWNORMAL = 1;
        public const uint SW_NORMAL = 1;
        public const uint SW_SHOWMINIMIZED = 2;
        public const uint SW_SHOWMAXIMIZED = 3;
        public const uint SW_MAXIMIZE = 3;
        public const uint SW_SHOWNOACTIVATE = 4;
        public const uint SW_SHOW = 5;
        public const uint SW_MINIMIZE = 6;
        public const uint SW_SHOWMINNOACTIVE = 7;
        public const uint SW_SHOWNA = 8;
        public const uint SW_RESTORE = 9;
        public const uint SW_SHOWDEFAULT = 10;
        public const uint SW_FORCEMINIMIZE = 11;
        public const uint SW_MAX = 11;

        public const long WS_CAPTION = 0x00C00000L;
        public const long WS_DISABLED = 0x08000000L;
        public const long WS_VSCROLL = 0x00200000L;
        public const long WS_HSCROLL = 0x00100000L;
        public const long WS_MINIMIZEBOX = 0x00020000L;
        public const long WS_MAXIMIZEBOX = 0x00010000L;
        public const long WS_POPUP = 0x80000000L;
        public const long WS_SYSMENU = 0x00080000L;
        public const long WS_TABSTOP = 0x00010000L;
        public const long WS_VISIBLE = 0x10000000L;

        public static uint WPF_RESTORETOMAXIMIZED = 2;

        public const int INPUT_MOUSE = 0;
        public const int INPUT_KEYBOARD = 1;

        public const int MOUSEEVENTF_MOVE = 0x0001;
        public const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        public const int MOUSEEVENTF_LEFTUP = 0x0004;
        public const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        public const int MOUSEEVENTF_RIGHTUP = 0x0010;
        public const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        public const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        public const int MOUSEEVENTF_XDOWN = 0x0080;
        public const int MOUSEEVENTF_XUP = 0x0100;
        public const int MOUSEEVENTF_WHEEL = 0x0800;
        public const int MOUSEEVENTF_VIRTUALDESK = 0x4000;
        public const int MOUSEEVENTF_ABSOLUTE = 0x8000;

        public const int HourGlassValue = 65557;
    }
}