using NUnit.Framework;
using TestStack.White.UIItems;

namespace TestStack.White.UITests.ControlTests
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class ImageTests : WhiteUITestBase
    {
        public ImageTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [OneTimeSetUp]
        public void Setup()
        {
            SelectOtherControls();
        }

        [Test]
        public void GetTest()
        {
            SelectOtherControls();
            var image = MainWindow.Get<Image>("Image");
            Assert.That(image, Is.Not.Null);
        }
    }
}