using NUnit.Framework;
using White.Core.Testing;

namespace White.Core.UIItems.TabItems
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