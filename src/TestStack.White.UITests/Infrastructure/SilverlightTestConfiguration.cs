using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using TestStack.White.Configuration;
using TestStack.White.ScreenObjects;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UITests.Screens;
using TestStack.White.WebBrowser;

namespace TestStack.White.UITests.Infrastructure
{
    public class SilverlightTestConfiguration : TestConfiguration
    {
        public override Application LaunchApplication()
        {
            var processes = Process.GetProcessesByName("iexplore");
            foreach (var process in processes)
            {
                try
                {
                    process.Kill();
                }
                catch { }
            }

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

            var logger = CoreConfigurationLocator.Get().LoggerFactory.Create(typeof(SilverlightTestConfiguration));
            logger.Info(string.Format("Running {0} {1}", appcmd, deleteArgs));
            Process.Start(appcmd, deleteArgs).WaitForExit();
            logger.Info(string.Format("Running {0} {1}", appcmd, addArgs));
            Process.Start(appcmd, addArgs).WaitForExit();

            InternetExplorerFactory.Plugin();
            var processStartInfo = new ProcessStartInfo
            {
                FileName = "iexplore.exe",
                Arguments = "http://localhost/TestSilverlightApplication.Web/TestSilverlightApplicationTestPage.aspx"
            };
            return Application.Launch(processStartInfo);
        }

        public override Window GetMainWindow(Application application)
        {
            var ieWindow = (InternetExplorerWindow)application.GetWindow("TestSilverlightApplication - Windows Internet Explorer");
            return ieWindow.SilverlightDocument;
        }

        public override MainScreen GetMainScreen(ScreenRepository repository)
        {
            return null;
        }
    }
}