using System.Diagnostics;
using White.Core;

namespace White.WebBrowser
{
    public static class InternetExplorer
    {
        public static InternetExplorerWindow Launch(string url, string title)
        {
            InternetExplorerFactory.Plugin();
            var processStartInfo = new ProcessStartInfo {FileName = "iexplore.exe", Arguments = url};
            Application application = Application.Launch(processStartInfo);
            return (InternetExplorerWindow) application.GetWindow(title);
        }
    }
}