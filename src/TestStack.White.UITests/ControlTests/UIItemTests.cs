using System.Collections.Generic;
using TestStack.White.UITests.Infrastructure;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UIItems.ListBoxItems;
using White.Core.UIItems.WPFUIItems;

namespace TestStack.White.UITests.ControlTests
{
    public class UIItemTests : WhiteTestBase
    {
        protected override void RunTest(FrameworkId framework)
        {
            RunTest(CanClickOnElementsLocatedBySearchingThroughSeveralContainers);
        }

        void CanClickOnElementsLocatedBySearchingThroughSeveralContainers()
        {
            var groupBox = MainWindow.Get<GroupBox>(SearchCriteria.ByAutomationId("AGroupBox"));
            var listbox = groupBox.Get<ListBox>(SearchCriteria.ByAutomationId("CheckedListBox"));
            var listboxItem = listbox.Get<ListItem>(SearchCriteria.ByText("Item1"));
            
            listboxItem.Click();
        }

        protected override IEnumerable<FrameworkId> SupportedFrameworks()
        {
            yield return FrameworkId.Wpf;
        }
    }
}