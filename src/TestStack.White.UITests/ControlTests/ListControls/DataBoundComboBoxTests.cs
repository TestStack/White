using System.Collections.Generic;
using White.Core.Configuration;
using White.Core.UIItems;
using White.Core.UIItems.ListBoxItems;
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
            ListItems items;
            CoreAppXmlConfiguration.Instance.ComboBoxItemsPopulatedWithoutDropDownOpen = false;
            try
            {
                items = ComboBoxUnderTest.Items;
                Assert.Equal(0, items.Count);
            }
            finally
            {
                CoreAppXmlConfiguration.Instance.ComboBoxItemsPopulatedWithoutDropDownOpen = true;
            }

            items = ComboBoxUnderTest.Items;
            Assert.Equal(5, items.Count);
            Assert.Equal("Test", items[0].Text);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
        }
    }
}