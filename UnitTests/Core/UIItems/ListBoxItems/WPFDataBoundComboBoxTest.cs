using NUnit.Framework;
using White.Core;
using White.Core.Configuration;
using White.Core.UIItems.ListBoxItems;
using White.UnitTests.Core.Testing;

namespace White.UnitTests.Core.UIItems.ListBoxItems
{
    [TestFixture, WPFCategory]
    public class WPFDataBoundComboBoxTest : ControlsActionTest
    {
        protected override string CommandLineArguments
        {
            get { return WPFScenarioSet1; }
        }

        [Test]
        public void Select()
        {
            CoreAppXmlConfiguration.Instance.ComboBoxItemsPopulatedWithoutDropDownOpen = false;
            try
            {
                ListItems items = window.Get<ComboBox>("dataBoundComboBox").Items;
                Assert.AreEqual(1, items.Count);
                Assert.AreEqual("S P Kumar", items[0].Text);
            }
            finally
            {
                CoreAppXmlConfiguration.Instance.ComboBoxItemsPopulatedWithoutDropDownOpen = true;
            }
        }
    }
}