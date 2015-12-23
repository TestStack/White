using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.UITests.ControlTests.MenuItems
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class MenuTests : WhiteUITestBase
    {
        public MenuTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [Test]
        public void FindMenuBarTest()
        {
            Assert.That(MainWindow.MenuBar, Is.Not.Null);
            Assert.That(MainWindow.MenuBar.MenuItem("File"), Is.Not.Null);
            Assert.That(MainWindow.MenuBars, Has.Count.EqualTo(1));
        }

        [Test]
        public void ClickTest()
        {
            var menu = MainWindow.MenuBar.MenuItem("File", "Click Me");
            menu.Click();
            Assert.That("Click Me Clicked", Is.EqualTo(MainWindow.HelpText));
        }

        [Test]
        public void FindByAutomationIdTest()
        {
            if (Framework != WindowsFramework.Wpf)
            {
                Assert.Ignore();
            }
            var menuBar = MainWindow.MenuBar;
            Assert.That(menuBar.MenuItemBy(SearchCriteria.ByAutomationId("FileId")), Is.Not.Null);
        }

        [Test]
        public void FindMultiLevelMenuItemTest()
        {
            var menuBar = MainWindow.MenuBar;
            var menu = menuBar.MenuItem("Multi-Level Menu");
            Assert.That(menu.SubMenu(SearchCriteria.ByText("Level 1")).SubMenu("Level 2").SubMenu("Level 3"), Is.Not.Null);
        }
    }
}