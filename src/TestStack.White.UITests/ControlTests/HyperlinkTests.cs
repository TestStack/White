using NUnit.Framework;
using System.Windows;
using TestStack.White.UIItems;

namespace TestStack.White.UITests.ControlTests
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class HyperlinkTests : WhiteUITestBase
    {
        public HyperlinkTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [OneTimeSetUp]
        public void Setup()
        {
            SelectOtherControls();
        }

        [Test]
        [Category("NeedsFix")]
        [Ignore("NeedsFix")]
        public void ClickTest()
        {
            var hyperlink = MainWindow.Get<Hyperlink>("LinkLabel");
            hyperlink.Click(10, 10);
            Assert.That(hyperlink.HelpText, Is.EqualTo("Hyperlink Clicked"));
        }

        [Test]
        public void ClickablePointTest()
        {
            if (Framework != WindowsFramework.Wpf)
            {
                //TODO Figure out why this fails for Windows Forms
                Assert.Inconclusive("This should actually work");
            }
            var hyperlink = MainWindow.Get<Hyperlink>("LinkLabel");
            hyperlink.Focus();
            var clickablePoint = hyperlink.ClickablePoint;

            Assert.That(clickablePoint, Is.Not.EqualTo(new Point(0, 0)));
            hyperlink.Click();
            Assert.That(hyperlink.HelpText, Is.EqualTo("Hyperlink Clicked"));
        }

        [Test]
        public void ClickHyperlinkFromLabelTest()
        {
            if (Framework != WindowsFramework.Wpf)
            {
                Assert.Ignore();
            }
            var labelContainingHyperlink = MainWindow.Get<WPFLabel>("LinkLabelContainer");
            var hyperlink = labelContainingHyperlink.Hyperlink("Link Text");
            hyperlink.Click();
            Assert.That(hyperlink.HelpText, Is.EqualTo("Hyperlink Clicked"));
        }
    }
}