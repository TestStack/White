using System.Windows.Automation;
using NUnit.Framework;
using White.Core.Configuration;
using White.Core.UIItems.ListBoxItems;
using White.Core.UITests.Testing;
using log4net;

namespace White.Core.UITests.UIItems.ListBoxItems
{
    [TestFixture]
    public class ComboBoxTest : ControlsActionTest
    {
        private ComboBox comboBox;

        protected override void TestFixtureSetUp()
        {
            comboBox = window.Get<ComboBox>("komboBox");
            Assert.AreEqual(string.Empty, comboBox.SelectedItemText);
        }

        [Test]
        public void GetItems()
        {
            var expandCollapsePattern = ((ExpandCollapsePattern) comboBox.AutomationElement.GetCurrentPattern(ExpandCollapsePattern.Pattern));
            expandCollapsePattern.Expand();
            expandCollapsePattern.Collapse();
            ListItems items = comboBox.Items;
            Assert.AreEqual(10, items.Count);
            Assert.AreEqual("Arundhati Roy", items[0].Name);
            Assert.AreEqual("Noam Chomsky", items[1].Name);
        }

        [Test]
        public void LaunchModalWindowOnIndexChange()
        {
            var comboBoxLaunchingModal = window.Get<ComboBox>("comboBoxLaunchingModalWindow");
            comboBoxLaunchingModal.Select("Arundhati Roy");
            CloseModal(window);
        }

        [Test]
        public void SelectBasedOnIndex()
        {
            comboBox.Select(4);
            Assert.AreEqual("3", comboBox.SelectedItemText);
        }

        [Test]
        public void Select()
        {
            comboBox.Select("7");
            LogManager.GetLogger(typeof(ComboBoxTest)).Debug("Selecting Arundhati Roy");
            comboBox.Select("Arundhati Roy");
            Assert.AreEqual("Arundhati Roy", comboBox.SelectedItemText);
            comboBox.Select("Noam Chomsky");
            Assert.AreEqual("Noam Chomsky", comboBox.SelectedItemText);
        }

        [Test]
        public void SelectAfterScroll()
        {
            comboBox.Select("4");
            comboBox.Select("7");
            Assert.AreEqual("7", comboBox.SelectedItem.Text);
        }

        [Test]
        public void SelectItemHavingLongText()
        {
            comboBox.Select("ReallyReallyLongTextHere");
            Assert.AreEqual("ReallyReallyLongTextHere", comboBox.SelectedItem.Text);
        }

        [Test]
        public void SetValue()
        {
            comboBox.SetValue("4");
            Assert.AreEqual("4", comboBox.SelectedItem.Text);
        }
    }

    [TestFixture, WPFCategory]
    public class ComboBoxScenarioTest : ControlsActionTest
    {
        [Test]
        public void ListItemInComboBoxWithoutTextAvailableInitially()
        {
            try
            {
                CoreAppXmlConfiguration.Instance.ComboBoxItemsPopulatedWithoutDropDownOpen = false;
                var comboBox = window.Get<ComboBox>("ExampleComboBox");
                Assert.AreEqual(0, comboBox.Items.Count);
            }
            finally
            {
                CoreAppXmlConfiguration.Instance.ComboBoxItemsPopulatedWithoutDropDownOpen = true;
            }
        }

        [Test]
        public void ListItemInComboBoxWithTextAvailableInitially()
        {
            var comboBox = window.Get<ComboBox>("ExampleComboBox");
            Assert.AreEqual(8, comboBox.Items.Count);
        }
    }

    [TestFixture, WinFormCategory]
    public class WinFormComboBoxTest : ControlsActionTest
    {
        [Test]
        public void SetTextInComboBox()
        {
            var comboBox = window.Get<ComboBox>("komboBox");
            var winFormComboBox = (WinFormComboBox)comboBox;
            winFormComboBox.Text = "foo";
            Assert.AreEqual("foo", winFormComboBox.Text);
        }
    }
}