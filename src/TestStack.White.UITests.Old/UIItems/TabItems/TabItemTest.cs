using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UIItems.TabItems;
using TestStack.White.UITests.Testing;

namespace White.Core.UITests.UIItems.TabItems
{
    public class TabItemTest : ControlsActionTest
    {
        [Fact]
        public void FindControlsInsideTab()
        {
            ITabPage springTab = Window.Get<Tab>("seasons").SelectedTab;
            Assert.NotEqual(null, springTab);
            Window.Get<Button>("springyButton");
        }
    }
}