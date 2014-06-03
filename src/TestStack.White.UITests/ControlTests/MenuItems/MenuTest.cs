using System.Collections.Generic;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowStripControls;
using Xunit;

namespace TestStack.White.UITests.ControlTests.MenuItems
{
    public class MenuTest : WhiteTestBase
    {
        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            RunTest(FindMenuBar);
            RunTest(Click);
            RunTest(FindByAutomationId, WindowsFramework.Wpf);
            RunTest(FindMultiLevelMenuItem);
        }

        void FindMenuBar()
        {
            Assert.NotNull(MainWindow.MenuBar);
            Assert.NotNull(MainWindow.MenuBar.MenuItem("File"));
            Assert.Equal(1, MainWindow.MenuBars.Count);
        }

        void Click()
        {
            Menu menu = MainWindow.MenuBar.MenuItem("File", "Click Me");
            menu.Click();
            Assert.Equal(MainWindow.HelpText, "Click Me Clicked");
        }

        void FindByAutomationId()
        {
            MenuBar menuBar = MainWindow.MenuBar;
            Assert.NotNull(menuBar.MenuItemBy(SearchCriteria.ByAutomationId("FileId")));
        }

        void FindMultiLevelMenuItem()
        {
            MenuBar menuBar = MainWindow.MenuBar;
            Menu menu = menuBar.MenuItem("Multi-Level Menu");
            Assert.NotNull(menu.SubMenu(SearchCriteria.ByText("Level 1"))
                .SubMenu("Level 2")
                .SubMenu("Level 3"));
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
        }
    }
}