using System.Windows.Automation;
using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UIItems.ListBoxItems;
using White.Core.UIItems.WPFUIItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems.ListViewItems
{
    [TestFixture, WPFCategory]
    public class ListViewScenario2Test : ControlsActionTest
    {
        protected override string CommandLineArguments
        {
            get { return "ListViewScenarios"; }
        }

        [Fact]
        public void ScrollAndSelectInAComboBox()
        {
            var listView = Window.Get<ListView>("listView");
            ListViewRow row = listView.Rows[0];
            var comboBox = (ComboBox) row.Get(SearchCriteria.ByControlType(ControlType.ComboBox));
            Assert.NotEqual(null, comboBox);
            comboBox.Select("%");
            Assert.Equal("%", comboBox.SelectedItem.Text);
        }
    }
}