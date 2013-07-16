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
            RunTest(FindSubMenu);
            RunTest(Click);
            RunTest(FindByAutomationId, WindowsFramework.Wpf);
        }

        void FindMenuBar()
        {
            Assert.NotNull(MainWindow.MenuBar);
            Assert.NotNull(MainWindow.MenuBar.MenuItem("File"));
            Assert.Equal(1, MainWindow.MenuBars.Count);
        }

        void FindSubMenu()
        {
            Menu menu = MainWindow.MenuBar.MenuItem("File", "Click Me");
            Assert.NotNull(menu);
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

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
        }
    }
}