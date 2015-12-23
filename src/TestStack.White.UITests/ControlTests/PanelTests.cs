using NUnit.Framework;
using TestStack.White.UIItems;

namespace TestStack.White.UITests.ControlTests
{
    [TestFixture(WindowsFramework.WinForms)]
    public class PanelTests : WhiteUITestBase
    {
        public PanelTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [OneTimeSetUp]
        public void Setup()
        {
            SelectOtherControls();
        }

        [Test]
        public void ReadTextTest()
        {
            var panel = MainWindow.Get<Panel>("PanelWithText");
            Assert.That(panel.Text, Is.EqualTo("PanelText"));
        }
    }
}