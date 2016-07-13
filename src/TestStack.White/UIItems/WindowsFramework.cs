namespace TestStack.White.UIItems
{
    public enum WindowsFramework
    {
        [FrameworkId("")]
        None,
        [FrameworkId("WPF")]
        Wpf,
        Win32,
        [FrameworkId("WinForm")]
        WinForms,
        [FrameworkId("SWT")]
        Swt,
        InternetExplorer
    }
}