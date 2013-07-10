using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    [TestFixture, WinFormCategory]
    public class PanelTest : ControlsActionTest
    {
        [Fact]
        public void Text()
        {
            Panel panel = Window.Get<Panel>("panelWithText");
            Assert.Equal("PanelText", panel.Text);
        }
    }
}