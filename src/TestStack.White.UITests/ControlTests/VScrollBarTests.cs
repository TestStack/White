using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.Scrolling;

namespace TestStack.White.UITests.ControlTests
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class VScrollBarTests : WhiteUITestBase
    {
        private ListBox listBox;
        private IVScrollBar vScrollBar;
        private double smallChange;
        private double largeChange;

        public VScrollBarTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [OneTimeSetUp]
        public void Setup()
        {
            listBox = MainWindow.Get<ListBox>("ListBoxWithVScrollBar");
            vScrollBar = listBox.ScrollBars.Vertical;
            vScrollBar.ScrollDown();
            smallChange = vScrollBar.Value;
            vScrollBar.ScrollUp();
            vScrollBar.ScrollDownLarge();
            largeChange = vScrollBar.Value;
            vScrollBar.ScrollUpLarge();
            if (vScrollBar.IsNotMinimum)
            {
                vScrollBar.SetToMinimum();
            }
        }

        [Test]
        public void ShouldGetVerticalScrollBarTest()
        {
            Assert.That(vScrollBar, Is.Not.Null);
        }

        [Test]
        public void ShouldScrollDownTest()
        {
            var currentValue = vScrollBar.Value;
            vScrollBar.ScrollDown();
            vScrollBar.ScrollDown();
            vScrollBar.ScrollDown();
            vScrollBar.ScrollDown();
            vScrollBar.ScrollDown();
            Assert.That(vScrollBar.Value, Is.EqualTo(currentValue + (smallChange * 5)).Within(3));
        }

        [Test]
        public void ShouldScrollDownLarge()
        {
            var currentValue = vScrollBar.Value;
            vScrollBar.ScrollDownLarge();
            vScrollBar.ScrollDownLarge();
            vScrollBar.ScrollDownLarge();
            Assert.That(vScrollBar.Value, Is.EqualTo(currentValue + (largeChange * 3)).Within(3));
        }

        [Test]
        public void ShouldScrollUp()
        {
            vScrollBar.SetToMaximum();
            var maxValue = vScrollBar.Value;
            vScrollBar.ScrollUp();
            vScrollBar.ScrollUp();
            vScrollBar.ScrollUp();
            vScrollBar.ScrollUp();
            vScrollBar.ScrollUp();
            Assert.That(vScrollBar.Value, Is.EqualTo(maxValue - (smallChange * 5)).Within(3));
        }

        [Test]
        public void ShouldScrollUpLarge()
        {
            var currentValue = vScrollBar.Value;
            vScrollBar.ScrollUpLarge();
            vScrollBar.ScrollUpLarge();
            vScrollBar.ScrollUpLarge();
            Assert.That(vScrollBar.Value, Is.EqualTo(currentValue - (largeChange * 3)).Within(3));
        }
    }
}
