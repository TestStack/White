using NUnit.Framework;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowStripControls;
using TestStack.White.UITests.Testing;
using TestStack.White.WindowsAPI;

namespace White.Core.UITests.UIItems.MenuItems
{
    public class MenuTest : ControlsActionTest
    {
        [SetUp]
        public void SetUp()
        {
            Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.ESCAPE, Window);
            Keyboard.PressSpecialKey(KeyboardInput.SpecialKeys.ESCAPE, Window);
        }

        [Fact]
        public void FindMenuBar()
        {
            Assert.NotEqual(null, Window.MenuBar);
            Assert.NotEqual(null, Window.MenuBar.MenuItem("File"));
            Assert.Equal(1, Window.MenuBars.Count);
        }

        [Fact]
        public void FindSubMenu()
        {
            Menu menu = Window.MenuBar.MenuItem("File", "Click Me");
            Assert.NotEqual(null, menu);
        }

        [Fact]
        public void Click()
        {
            Menu menu = Window.MenuBar.MenuItem("File", "Click Me");
            menu.Click();
            AssertResultLabelText("Click Me Clicked");
        }

        [Fact]
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
        [Fact]
        public void FindByAutomationId()
        {
            MenuBar menuBar = Window.MenuBar;
            Assert.NotEqual(null, menuBar.MenuItemBy(SearchCriteria.ByAutomationId("FileId")));
        }
    }
}