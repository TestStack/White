using System.Collections.Generic;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UIItems.ListBoxItems;
using White.Core.UIItems.WPFUIItems;

namespace TestStack.White.UITests.ControlTests
{
    public class UIItemTests : WhiteTestBase
    {
        protected override void RunTest(WindowsFramework framework)
        {
            RunTest(can_click_on_elements_located_by_searching_through_several_containers);
        }

        void can_click_on_elements_located_by_searching_through_several_containers()
        {
            var groupBox = MainWindow.Get<GroupBox>(SearchCriteria.ByAutomationId("AGroupBox"));
            var listbox = groupBox.Get<ListBox>(SearchCriteria.ByAutomationId("CheckedListBox"));
            var listboxItem = listbox.Get<ListItem>(SearchCriteria.ByText("Item1"));
            
            listboxItem.Click();
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
        }
    }
}