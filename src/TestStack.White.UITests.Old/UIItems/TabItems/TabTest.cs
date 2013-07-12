using System.Windows.Automation;
using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TabItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UITests.Testing;

namespace White.Core.UITests.UIItems.TabItems
{
    public class TabTest : ControlsActionTest
    {
        protected Tab tab;

        protected override void TestFixtureSetUp()
        {
            tab = Window.Get<Tab>("seasons");
        }

        [Fact]
        public void Find()
        {
            Assert.NotEqual(null, tab);
        }

        [Fact]
        public void AssertChildrenCount()
        {
            Assert.Equal(3, tab.TabCount);
        }

        [Fact]
        public void ShouldSelectTabPage()
        {
            tab.SelectTabPage(0);
            Assert.Equal("Spring", tab.SelectedTab.Name);
            tab.SelectTabPage(1);
            Assert.Equal("Autumn", tab.SelectedTab.Name);
        }

        [Fact]
        public void ShouldSelectTabPageWithName()
        {
            tab.SelectTabPage("Spring");
            Assert.Equal("Spring", tab.SelectedTab.Name);
            tab.SelectTabPage("Autumn");
            Assert.Equal("Autumn", tab.SelectedTab.Name);
        }

        [Fact]
        public void FindControlsWithSameAutomationIdBasedOnTheirLocation()
        {
            tab.SelectTabPage("Winter");
            var textBox2 = Window.Get<TextBox>(GetSearchCriteria().AndIndex(1));
            var textBox1 = Window.Get<TextBox>(GetSearchCriteria().AndIndex(0));
            var exception = Assert.Throws<AutomationException>(() => Window.Get<TextBox>(GetSearchCriteria().AndIndex(2)));
            Assert.Equal("Failed to get ControlType=edit,AutomationId=duplicateBox,Index=2", exception.Message);

            textBox1.Text = "1";
            Assert.Equal("1", textBox1.Text);

            Assert.Equal(string.Empty, textBox2.Text);
            textBox2.Text = "2";
            Assert.Equal("2", textBox2.Text);
            textBox1.Text = textBox2.Text = string.Empty;
        }

        [Fact]
        public void FindUIItemsBasedOnControlTypeAndSearchCriteria()
        {
            tab.SelectTabPage("Winter");
            var box = Window.Get<TextBox>(SearchCriteria.ByControlType(ControlType.Edit).AndIndex(1));
            Assert.NotEqual(null, box);
        }

        private SearchCriteria GetSearchCriteria()
        {
            if (Window is Win32Window)
                return SearchCriteria.ByText("duplicateBox");
            return SearchCriteria.ByAutomationId("duplicateBox");
        }
    }
}