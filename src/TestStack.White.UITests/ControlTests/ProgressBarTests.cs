using NUnit.Framework;
using TestStack.White.UIItems;

namespace TestStack.White.UITests.ControlTests
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class ProgressBarTests : WhiteUITestBase
    {
        public ProgressBarTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [OneTimeSetUp]
        public void Setup()
        {
            SelectOtherControls();
        }

        [Test]
        public void MinimumValueTest()
        {
            var bar = MainWindow.Get<ProgressBar>("ProgressBar");
            Assert.That(bar.Minimum, Is.EqualTo(0));
        }

        [Test]
        public void MaximumValueTest()
        {
            var bar = MainWindow.Get<ProgressBar>("ProgressBar");
            Assert.That(bar.Maximum, Is.EqualTo(100));
        }

        [Test]
        public void ValueTest()
        {
            var bar = MainWindow.Get<ProgressBar>("ProgressBar");
            Assert.That(bar.Value, Is.EqualTo(50));
        }
    }
}