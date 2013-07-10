using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using White.Core.InputDevices;
using White.Core.UIA;
using White.Core.UIItems;
using White.Core.Utility;
using Xunit;

namespace TestStack.White.UITests.InputDevices
{
    public class MouseTest : WhiteTestBase
    {
        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            RunTest(Cursor);
            RunTest(Location);
            RunTest(RightClick);
        }

        void Cursor()
        {
            MouseCursor cursor = Mouse.Instance.Cursor;

            Assert.NotNull(cursor);
        }

        void Location()
        {
            Mouse mouse = Mouse.Instance;
            var point = new Point(100, 100);
            Assert.NotEqual(point, mouse.Location);
            mouse.Location = point;
            Retry.For(()=>Assert.Equal(point, mouse.Location), TimeSpan.FromSeconds(5));
        }

        void RightClick()
        {
            var button = MainWindow.Get<Button>("ButtonWithTooltip");
            Mouse.Instance.Location = button.Bounds.Center();
            Mouse.Instance.RightClick();

            Retry.For(()=>Assert.Equal("Right click received", button.Text), TimeSpan.FromSeconds(5));
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
        }
    }
}