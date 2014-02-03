using System.Collections.Generic;
using TestStack.White.Configuration;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests.ListControls
{
    public class DataBoundComboBoxTests : WhiteTestBase
    {
        protected ComboBox ComboBoxUnderTest { get; set; }

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            ComboBoxUnderTest = MainWindow.Get<ComboBox>("DataBoundComboBox");
            RunTest(CanSelectDataboundItems);
        }

        private void CanSelectDataboundItems()
        {
            var config = CoreAppXmlConfiguration.Instance;
            bool oldValue = config.ComboBoxItemsPopulatedWithoutDropDownOpen;
            config.ComboBoxItemsPopulatedWithoutDropDownOpen = true;
            try
            {
                ListItems items = ComboBoxUnderTest.Items;
                Assert.Equal(0, items.Count);

                config.ComboBoxItemsPopulatedWithoutDropDownOpen = false;

                items = ComboBoxUnderTest.Items;
                Assert.Equal(5, items.Count);
                Assert.Equal("Test", items[0].Text);
            }
            finally
            {
                config.ComboBoxItemsPopulatedWithoutDropDownOpen = oldValue;
            }
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
        }
    }
}