using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using White.Core.Configuration;
using White.Core.UIItems.WindowItems;
using Xunit;

namespace White.Core.UITests
{
    [TestFixture, SWTCategory, Ignore]
    public class DesktopTest
    {
        [Test, Ignore]
        public void Experiment()
        {
            Console.WriteLine(CoreAppXmlConfiguration.Instance.WorkSessionLocation);
        }

        [Fact]
        public void GetDesktopWindows()
        {
            List<Window> windows = Desktop.Instance.Windows();
            Assert.Equal(true, windows.Count > 0);
            bool panelTreatedAsWindow = windows.Exists(window => window.Title == "Program Manager");
            Assert.Equal(true, panelTreatedAsWindow);
        }

        [Fact]
        public void GetWindowsWhenConsoleWindowIsPresent()
        {
            Process process = Process.Start("cmd.exe");
            try
            {
                List<Window> windows = Desktop.Instance.Windows();
                Assert.Equal(true, windows.Count > 0);
            }
            finally
            {
                if (process != null) process.Kill();
            }
        }

        [Fact]
        public void Icons()
        {
            Assert.NotEqual(0, Desktop.Instance.Icons);
        }
    }
}