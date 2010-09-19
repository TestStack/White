using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    [TestFixture, WPFCategory]
    public class WPFHyperlinkTest : ControlsActionTest
    {
        [Test]
        public void ClickHyperlink()
        {
            WPFLabel labelContainingHyperlink = window.Get<WPFLabel>("linkLabel");
            labelContainingHyperlink.Hyperlink("Link Text").Click();
            AssertResultLabelText("Link label clicked");
        }

        [Test]
        public void ClickHyperlinkLlaunchedModal()
        {
            WPFLabel labelContainingHyperlink = window.Get<WPFLabel>("hyperlinkLaunchesModal");
            labelContainingHyperlink.Hyperlink("Launch Modal").Click();
            CloseModal(window);
        }
    }
}