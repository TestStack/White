using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using White.Core.Configuration;

namespace White.WebBrowser.UITests
{
    public abstract class SilverlightTestFixture : IDisposable
    {
        protected InternetExplorerWindow BrowserWindow;

        protected SilverlightTestFixture()
        {
            string fullPath;
            var checkoutDir = Environment.GetEnvironmentVariable("checkoutDir");
            if (string.IsNullOrEmpty(checkoutDir))
            {
                fullPath = Path.GetFullPath
                    (
                        Path.Combine
                            (
                                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                                @"..\..\..\..\..\..\TestApplications\TestSilverlightApplication.Web"
                            )
                    );
            }
            else
            {
                const string pathToApp = @"SilverlightTestApplication";
                fullPath = Path.GetFullPath(Path.Combine(checkoutDir, pathToApp));
            }
            var appcmd = string.Format(@"{0}\system32\inetsrv\AppCmd.exe", Environment.GetEnvironmentVariable("windir"));
            var addArgs = string.Format("add app /site.name:\"Default Web Site\" /path:/TestSilverlightApplication.Web /physicalPath:\"{0}\"", fullPath); 
            const string deleteArgs = "delete app /app.name:\"Default Web Site\\TestSilverlightApplication.Web\"";
            
            var logger = CoreAppXmlConfiguration.Instance.LoggerFactory.Create(typeof (SilverlightTestFixture));
            logger.Info(string.Format("Running {0} {1}", appcmd, deleteArgs));
            Process.Start(appcmd, deleteArgs).WaitForExit();
            logger.Info(string.Format("Running {0} {1}", appcmd, addArgs));
            Process.Start(appcmd, addArgs).WaitForExit();

            var processes = Process.GetProcessesByName("iexplore");
            foreach (var process in processes)
            {
                try
                {
                    process.Kill();
                }
                catch { }
            }
            BrowserWindow = InternetExplorer.Launch("http://localhost/TestSilverlightApplication.Web/TestSilverlightApplicationTestPage.aspx",
                                                    "TestSilverlightApplication - Windows Internet Explorer");
            PostSetup();
        }

        protected virtual void PostSetup()
        {
        }

        public void Dispose()
        {
            if (BrowserWindow != null)
                BrowserWindow.Dispose();

            var processes = Process.GetProcessesByName("iexplore");
            foreach (var process in processes)
            {
                try
                {
                    process.Kill();
                }
                catch { }
            }
        }
    }
}