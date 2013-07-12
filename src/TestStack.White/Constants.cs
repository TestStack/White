using TestStack.White.Configuration;

namespace TestStack.White
{
    public static class Constants
    {
        public const string WPFFrameworkId = "WPF";
        public const string WinFormFrameworkId = "WinForm";
        public const string Win32FrameworkId = "Win32";
        public const string MissingFrameworkId = "";
        public const string SWT = "SWT";
        public const string SilverlightFrameworkId = "Silverlight";

        public static string BusyMessage
        {
            get { return string.Format(", after waiting for {0} ms", CoreAppXmlConfiguration.Instance.BusyTimeout); }
        }
    }
}