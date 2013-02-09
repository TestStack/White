using System;

namespace TestStack.White.UITests.Infrastructure
{
    [Flags]
    public enum FrameworkId
    {
        Wpf = 1,
        Winforms = 2,
        Silverlight = 4,
        Swt = 8,
        Win32 = 16,
        WinRT = 32
    }
}