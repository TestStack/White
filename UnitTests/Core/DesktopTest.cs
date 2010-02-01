using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using White.Core;
using White.Core.UIItems.Finders;
using White.Core.UIItems.WindowItems;

namespace White.UnitTests.Core
{
    [TestFixture, NormalCategory]
    public class DesktopTest
    {
        [Test, Ignore]
        public void Experiment()
        {
            var window = Application.Attach("Notepad").GetWindows()[0];
            var element = window.Get(SearchCriteria.ByText("Save As"));
            Assert.AreNotEqual(null, element);
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
                if (process != null) process.Kill();
            }
        }

        [Test]
        public void Icons()
        {
            Assert.AreNotEqual(0, Desktop.Instance.Icons);
        }
    }
}