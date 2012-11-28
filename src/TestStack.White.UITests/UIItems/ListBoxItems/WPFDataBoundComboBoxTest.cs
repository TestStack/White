using System.Windows.Automation;
using NUnit.Framework;
using White.Core.Configuration;
using White.Core.UIItems.ListBoxItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems.ListBoxItems
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
            ListItems items;
            CoreAppXmlConfiguration.Instance.ComboBoxItemsPopulatedWithoutDropDownOpen = false;
            try
            {
                var comboBox = window.Get<ComboBox>("dataBoundComboBox");
                items = comboBox.Items;
                Assert.AreEqual(0, items.Count);
            }
            finally
            {
                CoreAppXmlConfiguration.Instance.ComboBoxItemsPopulatedWithoutDropDownOpen = true;
            }

            items = window.Get<ComboBox>("dataBoundComboBox").Items;
            Assert.AreEqual(1, items.Count);
            Assert.AreEqual("S P Kumar", items[0].Text);
        }

        [Test]
        public void SetValueInEditableComboBox()
        {
            var comboBox = window.Get<ComboBox>("editableComboBox");
            comboBox.EditableText = "foobar";
            Assert.AreEqual("foobar", comboBox.EditableText);
        }

        [Test]
        public void SelectItemInEditableComboBox()
        {
            var comboBox = window.Get<ComboBox>("editableComboBox");
            var expandPatter = (ExpandCollapsePattern)comboBox.AutomationElement.GetCurrentPattern(ExpandCollapsePattern.Pattern);
            expandPatter.Expand();
            expandPatter.Collapse();
            comboBox.Select("whatever");
            Assert.AreEqual("whatever", comboBox.EditableText);
            Assert.AreEqual("whatever", comboBox.SelectedItemText);
        }
    }
}