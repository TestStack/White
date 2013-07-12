using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using White.Core;
using White.Core.UIItems.WindowItems;
using White.WebBrowser.Config;

namespace White.WebBrowser
{
    public class Firefox
    {
        public static FirefoxWindow Launch(string url)
        {
            const string executableName = "firefox";
            const string executable = executableName + ".exe";

            int numberBeforeLaunch = Process.GetProcessesByName(executableName).Length;

            Application existingApplication = null;
            List<Window> existingWindows = null;
            if (numberBeforeLaunch != 0)
            {
                existingApplication = Application.Attach(executableName);
                existingWindows = existingApplication.GetWindows();
            }

            string commandLine = string.Format("-new-window {0}", url);
            var processStartInfo = new ProcessStartInfo {FileName = executable, Arguments = commandLine};
            Application application = Application.Launch(processStartInfo);
            Thread.Sleep(WebBrowserAppXmlConfiguration.Instance.FirefoxSingleWindowCheckWait);
            int numberOfFirefoxProcessesAfterLaunch = Process.GetProcessesByName(executableName).Length;
            bool processPerWindow = numberOfFirefoxProcessesAfterLaunch > numberBeforeLaunch;

            FirefoxFactory.Plugin();
            if (processPerWindow)
            {
                List<Window> windows = application.GetWindows();
                if (windows.Count == 0) throw new WhiteAssertionException("Could not find firefox window");
                return (FirefoxWindow) windows[0];
            }

            List<Window> firefoxWindows = existingApplication.GetWindows();
            firefoxWindows.RemoveAll(window => existingWindows.Contains(window));
            return (FirefoxWindow) firefoxWindows[0];
        }
    }
}