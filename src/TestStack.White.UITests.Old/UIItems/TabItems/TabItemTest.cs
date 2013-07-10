using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UIItems.TabItems;
using White.Core.UITests.Testing;

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