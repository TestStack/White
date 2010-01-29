using White.Core.UIItems.WPFUIItems;
using NUnit.Framework;
using White.Core.UIItems.Finders;
using White.UnitTests.Core.Testing;

namespace White.Core.UIItems.ListBoxItems
{
    [TestFixture, WPFCategory]
    public class WPFListBoxTest : ControlsActionTest
    {
        [Test]
        public void ListItemContainingTextbox()
        {
            var listBox = window.Get<ListBox>("listBox");
            var listItem = (WPFListItem) listBox.Items.Find(item => "Hrishikesh".Equals(item.Text));
            var textBox = listItem.Get<TextBox>(SearchCriteria.All);
            Assert.AreNotEqual(null, textBox);
            textBox.Text = "Hrishikesh M";
            Assert.AreEqual("Hrishikesh M", listItem.Text);
        }

        [Test]
        public void ListBoxWithScrollBarWithChangingItems()
        {
            var listBox = window.Get<ListBox>("listBoxWithDynamicItems");
            listBox.Select("One");
            listBox.Select("17");
            window.Get<Button>("changeLanguage").Click();
            listBox.Select("Teen");
        }
    }
}