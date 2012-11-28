using NUnit.Framework;
using White.Core.UIItems.MenuItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    [TestFixture, SWTCategory, Ignore]
    public class SWTMenuTest : ControlsActionTest
    {
        [Test]
        public void SubMenu()
        {
            Menu menu = window.MenuBar.MenuItem("File", "Click Me Too", "Leaf");
            Assert.AreNotEqual(null, menu);
        }
    }
}