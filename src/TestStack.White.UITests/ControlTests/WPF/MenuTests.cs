using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using TestStack.White.UITests.Infrastructure;
using White.Core.UIItems.Finders;
using White.Core.UIItems.WindowStripControls;

namespace TestStack.White.UITests.ControlTests.WPF
{
    public class MenuTests : WhiteTestBase
    {
        protected MenuBar MenuUnderTest { get; set; }

        protected override void RunTest(FrameworkId framework)
        {
            MenuUnderTest = MainWindow.Get<MenuBar>(SearchCriteria.ByAutomationId("MenuBar"));

            RunTest(CanClickMenuItemTwice);
        }

        public void CanClickMenuItemTwice()
        {
            var firstMenu = MenuUnderTest.TopLevelMenu[0];
            Assert.IsNotNull(firstMenu);
            // to make menu items visible
            firstMenu.Click();

            var menuitem = firstMenu.SubMenu("ClickMe");
            Assert.IsNotNull(menuitem);
            menuitem.Click();
            Assert.AreEqual("Clicked 1", menuitem.Name);

            firstMenu.Click();
            Thread.Sleep(1000);
            menuitem.Click();
            Assert.AreEqual("Clicked 2", menuitem.Name);

            firstMenu.Click();
            Thread.Sleep(1000);
            menuitem.Click();
            Assert.AreEqual("Clicked 3", menuitem.Name);
        }

        protected override IEnumerable<FrameworkId> SupportedFrameworks()
        {
            yield return FrameworkId.Wpf;
        }
    }
}
