using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using NUnit.Framework;

namespace White.WebBrowser.UITests
{
    public abstract class SilverlightTestFixture
    {
        protected InternetExplorerWindow BrowserWindow;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            var fullPath = Path.GetFullPath(Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                @"..\..\..\..\..\..\TestApplications\TestSilverlightApplication.Web"));
            var appcmd = string.Format(@"{0}\system32\inetsrv\AppCmd.exe", Environment.GetEnvironmentVariable("windir"));
            Process.Start(
                appcmd,
                string.Format("add app /site.name:\"Default Web Site\" /path:/TestSilverlightApplication.Web /physicalPath:\"{0}\"", fullPath));
             

            Process[] processes = Process.GetProcessesByName("iexplore");
            foreach (var process in processes)
            {
                try
                {
                    process.Kill();
                }
                catch
                {
                }
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
            BrowserWindow.Dispose();
        }
    }
}