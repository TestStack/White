using NUnit.Framework;
using System;
using System.Windows.Automation;
using TestStack.White.UIA;
using TestStack.White.UIItems;

namespace TestStack.White.UITests.UIA
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class AutomationElementXTests : WhiteUITestBase
    {
        public AutomationElementXTests(WindowsFramework framework)
            : base(framework)
        { }

        [Test]
        public void ToStringTest()
        {
            var button = MainWindow.Get<Button>("ButtonWithTooltip");
            var display = button.AutomationElement.Display();
            Assert.That(display, Is.EqualTo(String.Format("AutomationId:ButtonWithTooltip, Name:Button with Tooltip, ControlType:{0}, FrameworkId:{1}", ControlType.Button.LocalizedControlType, FrameworkId)));
        }
    }
}