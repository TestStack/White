using System.Collections.Generic;
using System.Windows.Automation;
using TestStack.White.Configuration;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests.ListControls
{
    public class ComboBoxTests : WhiteTestBase
    {
        protected ComboBox ComboBoxUnderTest { get; set; }

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            ComboBoxUnderTest = MainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("AComboBox"));
            RunTest(ListItemInComboBoxWithoutTextAvailableInitially, WindowsFramework.Wpf);
            RunTest(ComboBoxWithAutoExpandCollapsedOnceItemsAreRetrieved);
            RunTest(ComboBoxOnlyCollapsesWhenExpansionWasForItemRetrieval);
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
            var config = CoreAppXmlConfiguration.Instance;
            var originalVal = config.ComboBoxItemsPopulatedWithoutDropDownOpen;
            try
            {
                config.ComboBoxItemsPopulatedWithoutDropDownOpen = true;
                Assert.Equal(0, ComboBoxUnderTest.Items.Count);
            }
            finally
            {
                config.ComboBoxItemsPopulatedWithoutDropDownOpen = originalVal;
            }
        }

        void ComboBoxOnlyCollapsesWhenExpansionWasForItemRetrieval()
        {
            // Arrange
            var config = CoreAppXmlConfiguration.Instance;
            var originalVal = config.ComboBoxItemsPopulatedWithoutDropDownOpen;
            config.ComboBoxItemsPopulatedWithoutDropDownOpen = false;

            try
            {
                ComboBoxUnderTest.Expand();

                // Act
#pragma warning disable 168
// ReSharper disable once UnusedVariable
                var items = ComboBoxUnderTest.Items;
#pragma warning restore 168

                // Assert
                var expansionState = ComboBoxUnderTest.ExpandCollapseState;
                Assert.Equal(ExpandCollapseState.Expanded, expansionState);
            }
            finally
            {
                config.ComboBoxItemsPopulatedWithoutDropDownOpen = originalVal;
                ComboBoxUnderTest.Collapse();
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
// ReSharper disable once UnusedVariable
                var items = ComboBoxUnderTest.Items;
#pragma warning restore 168

                // Assert
                var expansionState = ComboBoxUnderTest.ExpandCollapseState;
                // The combobox should have been collapsed after the items were retrieved
                Assert.Equal(ExpandCollapseState.Collapsed, expansionState);
            }
            finally
            {
                config.ComboBoxItemsPopulatedWithoutDropDownOpen = originalVal;
            }

        }

        void CanSelectByIndex()
        {
            ComboBoxUnderTest.Select(4);
            Assert.Equal("Test5", ComboBoxUnderTest.SelectedItemText);
        }

        void CanSelectItemAtBottomOfList()
        {
            ComboBoxUnderTest.Select("Test19");
            Assert.Equal("Test19", ComboBoxUnderTest.SelectedItemText);
        }

        void CanGetAllItems()
        {
            var items = ComboBoxUnderTest.Items;
            Assert.Equal(21, items.Count);
            Assert.Equal("Test", items[0].Name);
            Assert.Equal("Test20", items[19].Name);
        }

        void CanSelectItemAtTopOfList()
        {
            ComboBoxUnderTest.Select("Test2");
            Assert.Equal("Test2", ComboBoxUnderTest.SelectedItemText);
        }

        void CanSelectReallyLongText()
        {
            ComboBoxUnderTest.Select("ReallyReallyReallyLongTextHere");
            Assert.Equal("ReallyReallyReallyLongTextHere", ComboBoxUnderTest.SelectedItem.Text);
        }

        void SetValue()
        {
            ComboBoxUnderTest.SetValue("Test4");
            Assert.Equal("Test4", ComboBoxUnderTest.SelectedItem.Text);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
        }
    }
}