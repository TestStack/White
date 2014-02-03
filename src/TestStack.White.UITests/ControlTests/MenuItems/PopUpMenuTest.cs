using System.Collections.Generic;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.MenuItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests.MenuItems
{
    public class PopUpMenuTest : WhiteTestBase
    {
        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            SelectListControls();
            RunTest(()=>GetPopupMenuItems(framework));
            RunTest(ClickOnPopupMenu);
            RunTest(ClickOnNestedMenu);
        }

        void GetPopupMenuItems(WindowsFramework framework)
        {
            MainWindow.Get<ListBox>("ListBoxWithVScrollBar").RightClick();
            var popup = MainWindow.Popup;
            int numberOfItems = framework == WindowsFramework.Wpf ? 2 : 4;
            Assert.Equal(numberOfItems, popup.Items.Count);
        }

        void ClickOnPopupMenu()
        {
            var listBox = MainWindow.Get<ListBox>("ListBoxWithVScrollBar");
            listBox.RightClick();
            Assert.True(MainWindow.HasPopup());
            Menu menu = MainWindow.PopupMenu("Root2");
            menu.Click();
            Assert.Equal("Root2 Clicked", listBox.LegacyHelpText);
        }

        void ClickOnNestedMenu()
        {
            var listBox = MainWindow.Get<ListBox>("ListBoxWithVScrollBar");
            listBox.RightClick();
            MainWindow.PopupMenu("Root", "Level1", "Level2").Click();
            Assert.Equal("Level 2 Clicked", listBox.LegacyHelpText);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
        }
    }
}