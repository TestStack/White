using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Scrolling;

namespace TestStack.White.UITests.ControlTests
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class HScrollBarTests : WhiteUITestBase
    {
        private IHScrollBar hScrollBar;

        public HScrollBarTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [OneTimeSetUp]
        public void Setup()
        {
            SelectInputControls();
            var textBox = MainWindow.Get<TextBox>("MultiLineTextBox");
            textBox.Text = "hfdsfjkhsdfjhdsfjhdsfhkjsdfhdsfkjhsdfjkdshfkjds " +
                           "fhsdkfhsdkfhhfdsfjkhsdfjhdsfjhdsfhkjsdfhdsfkjhsdf " +
                           "jkdshfkjdsfhsdkfhsdkfhhfdsfjkhsdfjhdsfjhdsfhkjsdfh " +
                           "dsfkjhsdfjkdshfkjdsfhsdkfhsdkfh";
            hScrollBar = textBox.ScrollBars.Horizontal;
            hScrollBar.SetToMinimum();
            hScrollBar.ScrollRightLarge();
            hScrollBar.ScrollLeftLarge();
        }

        [Test]
        public void ShouldGetHScrollBarTest()
        {
            Assert.That(hScrollBar, Is.Not.Null);
        }

        [Test]
        [Category("NeedsFix")]
        [Ignore("NeedsFix")]
        public void ShouldScrollRightTest()
        {
            var initialValue = hScrollBar.Value;
            hScrollBar.ScrollRight();
            Assert.That(hScrollBar.Value, Is.GreaterThan(initialValue));
        }

        [Test]
        [Category("NeedsFix")]
        [Ignore("NeedsFix")]
        public void ShouldScrollRightLargeTest()
        {
            var initialValue = hScrollBar.Value;
            hScrollBar.ScrollRightLarge();
            Assert.That(hScrollBar.Value, Is.GreaterThan(initialValue));
        }

        [Test]
        [Category("NeedsFix")]
        [Ignore("NeedsFix")]
        public void ShouldScrollLeftTest()
        {
            hScrollBar.ScrollRightLarge();
            var valueBeforeScrollLeft = hScrollBar.Value;
            hScrollBar.ScrollLeft();
            Assert.That(hScrollBar.Value, Is.LessThan(valueBeforeScrollLeft));
        }
    }
}