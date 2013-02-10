using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using White.Core.Configuration;

namespace White.WebBrowser.UITests
{
    public abstract class SilverlightTestFixture
    {
        protected InternetExplorerWindow BrowserWindow;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
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
            var args = string.Format("add app /site.name:\"Default Web Site\" /path:/TestSilverlightApplication.Web /physicalPath:\"{0}\"", fullPath);

            CoreAppXmlConfiguration.Instance.LoggerFactory.Create(typeof(SilverlightTestFixture)).Info(string.Format("Running {0} {1}", appcmd, args));
            Process.Start(appcmd, args).WaitForExit();

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

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
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