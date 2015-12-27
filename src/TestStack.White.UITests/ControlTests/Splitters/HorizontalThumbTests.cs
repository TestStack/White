using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace TestStack.White.UITests.ControlTests.Splitters
{
    [TestFixture(WindowsFramework.Wpf)]
    // [TestFixture(WindowsFramework.Silverlight)] ; Has some timing issues
    public class HorizontalThumbTests : WhiteUITestBase
    {
        protected Window Window { get; set; }

        public HorizontalThumbTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [OneTimeSetUp]
        public void Setup()
        {
            MainWindow.Get<Button>("OpenHorizontalSplitterButton").Click();
            Window = MainWindow.ModalWindow("HorizontalGridSplitter");
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
            var originalX = thumb.Location.X;
            thumb.SlideHorizontally(50);
            Assert.That(thumb.Location.X, Is.EqualTo(originalX + 50));
        }
    }
}