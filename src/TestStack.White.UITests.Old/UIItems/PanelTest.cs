using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UITests.Testing;

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