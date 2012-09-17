using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UIItems.TabItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems.TabItems
{
    [TestFixture]
    public class TabItemTest : ControlsActionTest
    {
        [Test]
        public void FindControlsInsideTab()
        {
            ITabPage springTab = window.Get<Tab>("seasons").SelectedTab;
            Assert.AreNotEqual(null, springTab);
            window.Get<Button>("springyButton");
        }
    }
}