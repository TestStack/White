using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowStripControls;

namespace TestStack.White.UITests.ControlTests.WindowStripControls
{
    [TestFixture(WindowsFramework.Wpf)]
    public class StatusBarTests : WhiteUITestBase
    {
        private WPFStatusBar statusBar;

        public StatusBarTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [OneTimeSetUp]
        public void Setup()
        {
            statusBar = MainWindow.Get<WPFStatusBar>("StatusBar");
        }

        [Test]
        public void StatusBarTest()
        {
            Assert.That(statusBar, Is.Not.Null);
        }

        [Test]
        public void StatusBarItemTest()
        {
            var collection = statusBar.Items;
            Assert.That(collection, Has.Count.EqualTo(2));
            var label = (Label)collection[0];
            Assert.That(label.Text, Is.EqualTo("Status Item 1"));
        }
    }
}