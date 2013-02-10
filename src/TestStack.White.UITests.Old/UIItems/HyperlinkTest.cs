using System.Windows;
using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    public abstract class HyperlinkTest : ControlsActionTest
    {
        [Test]
        public void Click()
        {
            var hyperlink = Window.Get<Hyperlink>("linkLabel");
            hyperlink.Click(10, 10);
            AssertResultLabelText("Link label clicked");
        }

        [Test]
        public void ClickLaunchesModalWindow()
        {
            var hyperlink = Window.Get<Hyperlink>("linkLaunchesModalWindow");
            hyperlink.Click();
            CloseModal(Window);
        }

        [Test]
        public void ClickablePoint()
        {
            var hyperlink = Window.Get<Hyperlink>("linkLabel");
            var clickablePoint = hyperlink.ClickablePoint;

            Assert.AreNotEqual(new Point(0, 0), clickablePoint);
            hyperlink.Click();
            AssertResultLabelText("Link label clicked");
        }
    }
}