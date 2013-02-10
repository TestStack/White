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
            Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.ESCAPE, Window);
            Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.ESCAPE, Window);
        }

        [Test]
        public void FindMenuBar()
        {
            Assert.AreNotEqual(null, Window.MenuBar);
            Assert.AreNotEqual(null, Window.MenuBar.MenuItem("File"));
            Assert.AreEqual(1, Window.MenuBars.Count);
        }

        [Test]
        public void FindSubMenu()
        {
            Menu menu = Window.MenuBar.MenuItem("File", "Click Me");
            Assert.AreNotEqual(null, menu);
        }

        [Test]
        public void Click()
        {
            Menu menu = Window.MenuBar.MenuItem("File", "Click Me");
            menu.Click();
            AssertResultLabelText("Click Me Clicked");
        }

        [Test]
        public void RaiseClickEvent()
        {
            Menu menu = Window.MenuBar.MenuItem("File", "Click Me");
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
            MenuBar menuBar = Window.MenuBar;
            Assert.AreNotEqual(null, menuBar.MenuItemBy(SearchCriteria.ByAutomationId("FileId")));
        }
    }
}