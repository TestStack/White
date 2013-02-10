using System.Windows.Automation;
using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UIItems.TabItems;
using White.Core.UIItems.WindowItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems.TabItems
{
    [TestFixture]
    public class TabTest : ControlsActionTest
    {
        protected Tab tab;

        protected override void TestFixtureSetUp()
        {
            tab = Window.Get<Tab>("seasons");
        }

        [Test]
        public void Find()
        {
            Assert.AreNotEqual(null, tab);
        }

        [Test]
        public void AssertChildrenCount()
        {
            Assert.AreEqual(3, tab.TabCount);
        }

        [Test]
        public void ShouldSelectTabPage()
        {
            tab.SelectTabPage(0);
            Assert.AreEqual("Spring", tab.SelectedTab.Name);
            tab.SelectTabPage(1);
            Assert.AreEqual("Autumn", tab.SelectedTab.Name);
        }

        [Test]
        public void ShouldSelectTabPageWithName()
        {
            tab.SelectTabPage("Spring");
            Assert.AreEqual("Spring", tab.SelectedTab.Name);
            tab.SelectTabPage("Autumn");
            Assert.AreEqual("Autumn", tab.SelectedTab.Name);
        }

        [Test]
        public void FindControlsWithSameAutomationIdBasedOnTheirLocation()
        {
            tab.SelectTabPage("Winter");
            var textBox2 = Window.Get<TextBox>(GetSearchCriteria().AndIndex(1));
            var textBox1 = Window.Get<TextBox>(GetSearchCriteria().AndIndex(0));
            var exception = Assert.Throws<AutomationException>(() => Window.Get<TextBox>(GetSearchCriteria().AndIndex(2)));
            Assert.AreEqual("Failed to get ControlType=edit,AutomationId=duplicateBox,Index=2", exception.Message);

            textBox1.Text = "1";
            Assert.AreEqual("1", textBox1.Text);

            Assert.AreEqual(string.Empty, textBox2.Text);
            textBox2.Text = "2";
            Assert.AreEqual("2", textBox2.Text);
            textBox1.Text = textBox2.Text = string.Empty;
        }

        [Test]
        public void FindUIItemsBasedOnControlTypeAndSearchCriteria()
        {
            tab.SelectTabPage("Winter");
            var box = Window.Get<TextBox>(SearchCriteria.ByControlType(ControlType.Edit).AndIndex(1));
            Assert.AreNotEqual(null, box);
        }

        private SearchCriteria GetSearchCriteria()
        {
            if (Window is Win32Window)
                return SearchCriteria.ByText("duplicateBox");
            return SearchCriteria.ByAutomationId("duplicateBox");
        }
    }
}