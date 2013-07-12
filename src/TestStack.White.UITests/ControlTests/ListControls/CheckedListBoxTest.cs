using System.Collections.Generic;
using System.Windows.Automation;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests.ListControls
{
    public class CheckedListBoxTest : WhiteTestBase
    {
        private ListBox listBoxUnderTest;

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            listBoxUnderTest = MainWindow.Get<ListBox>("CheckedListBox");
            RunTest(CanCheckItem);
            RunTest(CheckSelectedItem);
            RunTest(CheckUncheckItem);
        }

        void CanCheckItem()
        {
            Assert.Equal(false, listBoxUnderTest.IsChecked("Item1"));
            listBoxUnderTest.Check("Item1");
            Assert.Equal(true, listBoxUnderTest.IsChecked("Item1"));
        }

        void CheckSelectedItem()
        {
            Assert.Equal(false, listBoxUnderTest.IsChecked("Item2"));
            var item = listBoxUnderTest.Item("Item2");
            ((SelectionItemPattern)item.AutomationElement.GetCurrentPattern(SelectionItemPattern.Pattern))
                .Select();
            listBoxUnderTest.Check("Item2");
            Assert.Equal(true, listBoxUnderTest.IsChecked("Item2"));
        }

        public void CheckUncheckItem()
        {
            Assert.Equal(false, listBoxUnderTest.IsChecked("Item3"));
            listBoxUnderTest.Check("Item3");
            Assert.Equal(true, listBoxUnderTest.IsChecked("Item3"));

            listBoxUnderTest.UnCheck("Item3");
            Assert.Equal(false, listBoxUnderTest.IsChecked("Item3"));
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
        }
    }
}