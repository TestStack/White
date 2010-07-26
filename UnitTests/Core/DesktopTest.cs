using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using NUnit.Framework;
using White.Core;
using White.Core.Factory;
using White.Core.InputDevices;
using White.Core.UIItems.WindowItems;
using White.Core.WindowsAPI;

namespace White.UnitTests.Core
{
    [TestFixture, NormalCategory]
    public class DesktopTest
    {
        [Test, Ignore]
        public void Experiment()
        {
            Application application = Application.Launch(@"C:\Documents and Settings\All Users\Start Menu\Programs\Microsoft Office\Microsoft Office Excel 2007");
            Assert.IsNotNull(application);
            Thread.Sleep(10000); // // Find the main window 
            var window = application.GetWindow("Microsoft Excel - Book1", InitializeOption.NoCache);
            Assert.IsNotNull(window);
            AttachedKeyboard keyboard = window.Keyboard;
            keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.ALT);
            keyboard.Enter("y");
            keyboard.Enter("0");
            keyboard.Enter("1");
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