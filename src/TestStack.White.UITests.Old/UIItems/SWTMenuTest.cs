using NUnit.Framework;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    [TestFixture, SWTCategory, Ignore]
    public class SWTMenuTest : ControlsActionTest
    {
        [Fact]
        public void SubMenu()
        {
            Menu menu = Window.MenuBar.MenuItem("File", "Click Me Too", "Leaf");
            Assert.NotEqual(null, menu);
        }
    }
}