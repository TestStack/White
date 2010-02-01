using NUnit.Framework;
using White.UnitTests.Core.Testing;

namespace White.Core.UIItems.MenuItems
{
    [TestFixture, SWTCategory]
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