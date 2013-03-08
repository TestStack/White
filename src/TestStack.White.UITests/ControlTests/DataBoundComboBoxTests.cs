using System.Collections.Generic;
using NUnit.Framework;
using White.Core.Configuration;
using White.Core.UIItems;
using White.Core.UIItems.ListBoxItems;

namespace TestStack.White.UITests.ControlTests
{
    public class DataBoundComboBoxTests : WhiteTestBase
    {
        protected ComboBox ComboBoxUnderTest { get; set; }

        protected override void RunTest(WindowsFramework framework)
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
                Assert.AreEqual(0, items.Count);
            }
            finally
            {
                CoreAppXmlConfiguration.Instance.ComboBoxItemsPopulatedWithoutDropDownOpen = true;
            }

            items = ComboBoxUnderTest.Items;
            Assert.AreEqual(5, items.Count);
            Assert.AreEqual("Test", items[0].Text);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
        }
    }
}