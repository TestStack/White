using NUnit.Framework;
using White.Core.Testing;

namespace White.Core.UIItems
{
    public abstract class HyperlinkTest : ControlsActionTest
    {
        [Test]
        public void Click()
        {
            Hyperlink hyperlink = window.Get<Hyperlink>("linkLabel");
            hyperlink.Click(10, 10);
            AssertResultLabelText("Link label clicked");
        }

        [Test]
        public void ClickLaunchesModalWindow()
        {
            Hyperlink hyperlink = window.Get<Hyperlink>("linkLaunchesModalWindow");
            hyperlink.Click();
            CloseModal(window);
        }
    }
}