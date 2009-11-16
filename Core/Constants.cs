using White.Core.Configuration;

namespace White.Core
{
    public class Constants
    {
        public static readonly string WPFFrameworkId = "WPF";
        public static readonly string WinFormFrameworkId = "WinForm";
        public static readonly string Win32FrameworkId = "Win32";
        public static readonly string MissingFrameworkId = "";
        public static readonly string SWT = "SWT";
        public static readonly string SilverlightFrameworkId = "Silverlight";

        public static string BusyMessage
        {
            get { return string.Format(", after waiting for {0} ms", CoreAppXmlConfiguration.Instance.BusyTimeout); }
        }
    }
}