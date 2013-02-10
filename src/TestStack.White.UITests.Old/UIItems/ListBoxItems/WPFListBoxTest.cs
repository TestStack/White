using White.Core.UIItems;
using White.Core.UIItems.ListBoxItems;
using White.Core.UIItems.WPFUIItems;
using NUnit.Framework;
using White.Core.UIItems.Finders;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems.ListBoxItems
{
    [TestFixture, WPFCategory]
    public class WPFListBoxTest : ControlsActionTest
    {
        [Test]
        public void ListItemContainingTextbox()
        {
            var listBox = Window.Get<ListBox>("listBox");
            var listItem = (WPFListItem) listBox.Items.Find(item => "Hrishikesh".Equals(item.Text));
            var textBox = listItem.Get<TextBox>(SearchCriteria.All);
            Assert.AreNotEqual(null, textBox);
            textBox.Text = "Hrishikesh M";
            Assert.AreEqual("Hrishikesh M", listItem.Text);
        }

        [Test]
        public void FindNonExistentObject()
        {
            var listBox = Window.Get<ListBox>("listBox");
            var listItem = (WPFListItem)listBox.Items.Find(item => "Hrishikesh".Equals(item.Text));
            var exception = Assert.Throws<AutomationException>(() => listItem.Get<TextBox>(SearchCriteria.ByAutomationId("foo")));

            Assert.AreEqual("Failed to get ControlType=edit,AutomationId=foo", exception.Message);
        }

        [Test]
        public void ListBoxWithScrollBarWithChangingItems()
        {
            var listBox = Window.Get<ListBox>("listBoxWithDynamicItems");
            listBox.Select("One");
            listBox.Select("17");
            Window.Get<Button>("changeLanguage").Click();
            listBox.Select("Teen");
        }
    }
}