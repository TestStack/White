using System.Windows.Automation;
using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WPFUIItems;
using TestStack.White.UITests.Testing;

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