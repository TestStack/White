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
    }
}