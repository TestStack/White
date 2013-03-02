using System.Collections.Generic;
using Castle.Core.Logging;
using NUnit.Framework;
using TestStack.White.UITests.Infrastructure;
using White.Core.Configuration;
using White.Core.UIItems.Finders;
using White.Core.UIItems.ListBoxItems;

namespace TestStack.White.UITests.ControlTests
{
    public class ComboBoxTests : WhiteTestBase
    {
        protected ComboBox ComboBoxUnderTest { get; set; }

        protected override void RunTest(FrameworkId framework)
        {
            CoreAppXmlConfiguration.Instance.LoggerFactory = new ConsoleFactory(LoggerLevel.Debug); ;
            ComboBoxUnderTest = MainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("AComboBox"));
            RunTest(ListItemInComboBoxWithoutTextAvailableInitially, FrameworkId.Wpf);
            RunTest(CanSelectItemAtTopOfList);
            RunTest(CanGetAllItems);
            RunTest(CanSelectItemAtBottomOfList);
            RunTest(CanSelectItemAtTopOfList); // Once an item is selected at the bottom of the list, White couldn't select at the top again
            RunTest(CanSelectByIndex);
            RunTest(CanSelectReallyLongText);
            RunTest(SetValue);
        }

        void ListItemInComboBoxWithoutTextAvailableInitially()
        {
            try
            {
                CoreAppXmlConfiguration.Instance.ComboBoxItemsPopulatedWithoutDropDownOpen = false;
                Assert.AreEqual(0, ComboBoxUnderTest.Items.Count);
            }
            finally
            {
                CoreAppXmlConfiguration.Instance.ComboBoxItemsPopulatedWithoutDropDownOpen = true;
            }
        }

        void CanSelectByIndex()
        {
            ComboBoxUnderTest.Select(4);
            Assert.AreEqual("Test5", ComboBoxUnderTest.SelectedItemText);
        }

        void CanSelectItemAtBottomOfList()
        {
            ComboBoxUnderTest.Select("Test19");
            Assert.AreEqual("Test19", ComboBoxUnderTest.SelectedItemText);
        }

        void CanGetAllItems()
        {
            var items = ComboBoxUnderTest.Items;
            Assert.AreEqual(21, items.Count);
            Assert.AreEqual("Test", items[0].Name);
            Assert.AreEqual("Test20", items[19].Name);
        }

        void CanSelectItemAtTopOfList()
        {
            ComboBoxUnderTest.Select("Test2");
            Assert.AreEqual("Test2", ComboBoxUnderTest.SelectedItemText);
        }

        void CanSelectReallyLongText()
        {
            ComboBoxUnderTest.Select("ReallyReallyReallyLongTextHere");
            Assert.AreEqual("ReallyReallyReallyLongTextHere", ComboBoxUnderTest.SelectedItem.Text);
        }

        void SetValue()
        {
            ComboBoxUnderTest.SetValue("Test4");
            Assert.AreEqual("Test4", ComboBoxUnderTest.SelectedItem.Text);
        }

        protected override IEnumerable<FrameworkId> SupportedFrameworks()
        {
            yield return FrameworkId.Wpf;
            yield return FrameworkId.Winforms;
        }
    }
}