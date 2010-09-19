using NUnit.Framework;
using White.Core.UIItems.Finders;
using White.Core.UIItems.MenuItems;
using White.Core.UIItems.WindowStripControls;
using White.Core.UITests.Testing;
using White.Core.WindowsAPI;

namespace White.Core.UITests.UIItems.MenuItems
{
    [TestFixture]
    public class MenuTest : ControlsActionTest
    {
        [SetUp]
        public void SetUp()
        {
            keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.ESCAPE, window);
            keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.ESCAPE, window);
        }

        [Test]
        public void FindMenuBar()
        {
            Assert.AreNotEqual(null, window.MenuBar);
            Assert.AreNotEqual(null, window.MenuBar.MenuItem("File"));
            Assert.AreEqual(1, window.MenuBars.Count);
        }

        [Test]
        public void FindSubMenu()
        {
            Menu menu = window.MenuBar.MenuItem("File", "Click Me");
            Assert.AreNotEqual(null, menu);
        }

        [Test]
        public void Click()
        {
            Menu menu = window.MenuBar.MenuItem("File", "Click Me");
            menu.Click();
            AssertResultLabelText("Click Me Clicked");
        }
    }

    [TestFixture, WPFCategory]
    public class WinFormMenuTest : ControlsActionTest
    {
        [Test]
        public void FindByAutomationId()
        {
            MenuBar menuBar = window.MenuBar;
            Assert.AreNotEqual(null, menuBar.MenuItemBy(SearchCriteria.ByAutomationId("FileId")));
        }
    }
}