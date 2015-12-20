using NUnit.Framework;
using TestStack.White.UIItems;

namespace TestStack.White.UITests.ControlTests
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class TooltipTests : WhiteUITestBase
    {
        public TooltipTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [Test]
        public void CanGetTooltip()
        {
            var button = MainWindow.Get<Button>("ButtonWithTooltip");
            Assert.That(MainWindow.GetToolTipOn(button).Text, Is.EqualTo("I have a tooltip"));
        }
    }
}