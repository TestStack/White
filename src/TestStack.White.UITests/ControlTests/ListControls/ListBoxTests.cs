using System.Collections.Generic;
using TestStack.White.Configuration;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WPFUIItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests.ListControls
{
    public class ListBoxWithScrollBarTest : WhiteTestBase
    {
        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            RunTest(SelectItemNotVisibleBecauseOfScrollBar);
            RunTest(ListItemContainingTextbox, WindowsFramework.Wpf);
            RunTest(FindNonExistentObject, WindowsFramework.Wpf);
            RunTest(ListBoxWithScrollBarWithChangingItems, WindowsFramework.Wpf);
        }

        void SelectItemNotVisibleBecauseOfScrollBar()
        {
            var listBox = MainWindow.Get<ListBox>("ListBoxWithVScrollBar");
            listBox.Select("0");
            ListItem selectedItem = listBox.SelectedItem;
            Assert.Equal("0", selectedItem.Text);
        }

        void ListItemContainingTextbox()
        {
            var listBox = MainWindow.Get<ListBox>("ListBoxWpf");
            var listItem = (WPFListItem)listBox.Items.Find(item => "Hrishikesh".Equals(item.Text));
            var textBox = listItem.Get<TextBox>(SearchCriteria.All);
            Assert.NotNull(textBox);
            textBox.Text = "Hrishikesh M";
            Assert.Equal("Hrishikesh M", listItem.Text);
        }

        void FindNonExistentObject()
        {
            var listBox = MainWindow.Get<ListBox>("ListBoxWpf");
            var listItem = (WPFListItem)listBox.Items.Find(item => item.Text.StartsWith("Hrishikesh"));
            using (CoreAppXmlConfiguration.Instance.ApplyTemporarySetting(c => c.BusyTimeout = 100))
            {
                var exception = Assert.Throws<AutomationException>(() => listItem.Get<TextBox>(SearchCriteria.ByAutomationId("foo")));
                Assert.Equal("Failed to get ControlType=edit,AutomationId=foo", exception.Message);
            }
        }

        void ListBoxWithScrollBarWithChangingItems()
        {
            var listBox = MainWindow.Get<ListBox>("ListBoxWpf");
            listBox.Select("Spielberg");
            listBox.Select("Whedon");
            MainWindow.Get<Button>("ChangeListItems").Click();
            listBox.Select("Jackson");
            listBox.Select("Allen");
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
        }
    }
}