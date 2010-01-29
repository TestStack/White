using NUnit.Framework;
using White.UnitTests.Core.Testing;

namespace White.Core.UIItems
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