using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace TestStack.White.UITests.ControlTests.Splitters
{
    [TestFixture(WindowsFramework.Wpf)]
    // [TestFixture(WindowsFramework.Silverlight)] ; Has some timing issues
    public class VerticalThumbTests : WhiteUITestBase
    {
        protected Window Window { get; set; }

        public VerticalThumbTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [OneTimeSetUp]
        public void Setup()
        {
            MainWindow.Get<Button>("OpenVerticalSplitterButton").Click();
            Window = MainWindow.ModalWindow("VerticalGridSplitter");
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            Window.Close();
        }

        [Test]
        public void FindTest()
        {
            var thumb = Window.Get<Thumb>("Splitter");
            Assert.That(thumb, Is.Not.Null);
        }

        [Test]
        public void SlideTest()
        {
            var thumb = Window.Get<Thumb>("Splitter");
            var originalY = thumb.Location.Y;
            thumb.SlideVertically(50);
            Assert.That(thumb.Location.Y, Is.EqualTo(originalY + 50));
        }
    }
}