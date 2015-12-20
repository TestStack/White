using NUnit.Framework;
using TestStack.White.UIA;
using TestStack.White.UIItems;

namespace TestStack.White.UITests.UIA
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class AutomationElementXTest : WhiteUITestBase
    {
        public AutomationElementXTest(WindowsFramework framework) 
            : base(framework) { }

        [Test]
        public void TestToString()
        {
            var button = MainWindow.Get<Button>("ButtonWithTooltip");
            var display = button.AutomationElement.Display();
            Assert.That(display, Is.EqualTo(string.Format( "AutomationId:ButtonWithTooltip, Name:Button with Tooltip, ControlType:button, FrameworkId:{0}", FrameworkId)));
        }
    }
}