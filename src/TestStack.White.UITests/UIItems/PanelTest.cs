using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    [TestFixture, WinFormCategory]
    public class PanelTest : ControlsActionTest
    {
        [Test]
        public void Text()
        {
            Panel panel = window.Get<Panel>("panelWithText");
            Assert.AreEqual("PanelText", panel.Text);
        }
    }
}