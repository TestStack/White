using System.Collections.Generic;
using System.Windows.Automation;
using NUnit.Framework;
using TestStack.White.UITests.Infrastructure;
using White.Core.UIItems.ListBoxItems;

namespace TestStack.White.UITests.ControlTests
{
    public class CheckedListBoxTest : WhiteTestBase
    {
        private ListBox listBoxUnderTest;

        protected override void RunTest(FrameworkId framework)
        {
            listBoxUnderTest = MainWindow.Get<ListBox>("CheckedListBox");
            RunTest(CanCheckItem);
            RunTest(CheckSelectedItem);
            RunTest(CheckUncheckItem);
        }

        void CanCheckItem()
        {
            Assert.AreEqual(false, listBoxUnderTest.IsChecked("Item1"));
            listBoxUnderTest.Check("Item1");
            Assert.AreEqual(true, listBoxUnderTest.IsChecked("Item1"));
        }

        void CheckSelectedItem()
        {
            Assert.AreEqual(false, listBoxUnderTest.IsChecked("Item2"));
            var item = listBoxUnderTest.Item("Item2");
            ((SelectionItemPattern)item.AutomationElement.GetCurrentPattern(SelectionItemPattern.Pattern))
                .Select();
            listBoxUnderTest.Check("Item2");
            Assert.AreEqual(true, listBoxUnderTest.IsChecked("Item2"));
        }

        public void CheckUncheckItem()
        {
            Assert.AreEqual(false, listBoxUnderTest.IsChecked("Item3"));
            listBoxUnderTest.Check("Item3");
            Assert.AreEqual(true, listBoxUnderTest.IsChecked("Item3"));

            listBoxUnderTest.UnCheck("Item3");
            Assert.AreEqual(false, listBoxUnderTest.IsChecked("Item3"));
        }

        protected override IEnumerable<FrameworkId> SupportedFrameworks()
        {
            yield return FrameworkId.Wpf;
            yield return FrameworkId.Winforms;
            yield return FrameworkId.Silverlight;
        }
    }
}