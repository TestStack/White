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
            var hyperlink = window.Get<Hyperlink>("linkLabel");
            hyperlink.Click(10, 10);
            AssertResultLabelText("Link label clicked");
        }

        [Test]
        public void ClickLaunchesModalWindow()
        {
            var hyperlink = window.Get<Hyperlink>("linkLaunchesModalWindow");
            hyperlink.Click();
            CloseModal(window);
        }

        [Test]
        public void ClickablePoint()
        {
            var hyperlink = window.Get<Hyperlink>("linkLabel");
            var clickablePoint = hyperlink.ClickablePoint;

            Assert.AreNotEqual(new Point(0, 0), clickablePoint);
            hyperlink.Click();
            AssertResultLabelText("Link label clicked");
        }
    }
}