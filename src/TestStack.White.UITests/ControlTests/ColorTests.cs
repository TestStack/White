using NUnit.Framework;
using TestStack.White.UIItems;

namespace TestStack.White.UITests.ControlTests
{
    [TestFixture(WindowsFramework.WinForms)]
    public class ColorTests : WhiteUITestBase
    {
        public ColorTests(WindowsFramework framework)
            : base(framework) { }

        [OneTimeSetUp]
        public void Setup()
        {
            SelectInputControls();
        }

        [Test]
        public void BorderColourTest()
        {
            var blueTextBox = MainWindow.Get<TextBox>("BlueTextBox");
            var color = blueTextBox.BorderColor;
            Assert.That(color.R, Is.EqualTo(100));
            Assert.That(color.G, Is.EqualTo(100));
            Assert.That(color.B, Is.EqualTo(100));
        }

        [Test]
        public void DisplayAsImageTest()
        {
            var blueTextBox = MainWindow.Get<TextBox>("BlueTextBox");
            var bitmap = blueTextBox.VisibleImage;
            var color = bitmap.GetPixel(3, 3);
            Assert.That(color.B, Is.EqualTo(color.B));
            Assert.That(color.G, Is.EqualTo(color.G));
            Assert.That(color.R, Is.EqualTo(color.R));
        }
    }
}