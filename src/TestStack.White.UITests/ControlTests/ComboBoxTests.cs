using System.Collections.Generic;
using System.Windows.Automation;
using Castle.Core.Logging;
using NUnit.Framework;
using White.Core.Configuration;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UIItems.ListBoxItems;

namespace TestStack.White.UITests.ControlTests
{
    public class ComboBoxTests : WhiteTestBase
    {
        protected ComboBox ComboBoxUnderTest { get; set; }

        protected override void RunTest(WindowsFramework framework)
        {
            CoreAppXmlConfiguration.Instance.LoggerFactory = new ConsoleFactory(LoggerLevel.Debug);
            ComboBoxUnderTest = MainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("AComboBox"));
            RunTest(ListItemInComboBoxWithoutTextAvailableInitially, WindowsFramework.Wpf);
            RunTest(ComboBoxWithAutoExpandCollapsedOnceItemsAreRetrieved);
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

        void ComboBoxWithAutoExpandCollapsedOnceItemsAreRetrieved()
        {

            // Arrange
            var config = CoreAppXmlConfiguration.Instance;
            var originalVal = config.ComboBoxItemsPopulatedWithoutDropDownOpen;
            config.ComboBoxItemsPopulatedWithoutDropDownOpen = false;
            try
            {
                // Act
#pragma warning disable 168
                // Required to force the expansion of the combobox
                var items = ComboBoxUnderTest.Items;
#pragma warning restore 168

                // Assert
                var expansionState = (ExpandCollapseState)ComboBoxUnderTest.AutomationElement.GetCurrentPropertyValue(ExpandCollapsePattern.ExpandCollapseStateProperty);
                Assert.AreEqual(ExpandCollapseState.Collapsed, expansionState, "The combobox should have been collapsed after the items were retrieved");
            }
            finally
            {
                config.ComboBoxItemsPopulatedWithoutDropDownOpen = originalVal;
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

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
        }
    }
}