using NUnit.Framework;
using System;
using TestStack.White.UIItems;
using TestStack.White.Utility;
using TestStack.White.WindowsAPI;

namespace TestStack.White.UITests.ControlTests
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class HotKeyTests : WhiteUITestBase
    {
        public HotKeyTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [Test]
        public void AccessKeyTest()
        {
            var button = MainWindow.Get<Button>("ButtonWithTooltip");
            if (Framework != WindowsFramework.Wpf)
            {
                Assert.That(button.AccessKey, Is.EqualTo("Alt+B").IgnoreCase);
            }
            Keyboard.HoldKey(KeyboardInput.SpecialKeys.ALT);
            Keyboard.Enter("B");
            Keyboard.LeaveKey(KeyboardInput.SpecialKeys.ALT);
            Retry.For(() => Assert.That(button.Text, Is.EqualTo("Clicked")), TimeSpan.FromSeconds(2));
        }
    }
}