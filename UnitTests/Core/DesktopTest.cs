using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using White.Core.UIItems.WindowItems;

namespace White.Core
{
    [TestFixture, NormalCategory]
    public class DesktopTest
    {
        [Test, Ignore]
        public void Experiment()
        {
            Application application = Application.Attach(536);
            Window window = application.GetWindow("Yahoo! Messenger");
            Assert.AreNotEqual(null, window);
        }

        [Test]
        public void GetDesktopWindows()
        {
            List<Window> windows = Desktop.Instance.Windows();
            Assert.AreEqual(true, windows.Count > 0);
            bool panelTreatedAsWindow = windows.Exists(window => window.Title == "Program Manager");
            Assert.AreEqual(true, panelTreatedAsWindow);
        }

        [Test]
        public void GetWindowsWhenConsoleWindowIsPresent()
        {
            Process process = Process.Start("cmd.exe");
            try
            {
                List<Window> windows = Desktop.Instance.Windows();
                Assert.AreEqual(true, windows.Count > 0);
            }
            finally
            {
                process.Kill();
            }
        }

        [Test]
        public void Icons()
        {
            Assert.AreNotEqual(0, Desktop.Instance.Icons);
        }
    }
}