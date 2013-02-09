using NUnit.Framework;
using White.Core.UIItems.ListBoxItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems.ListBoxItems
{
    [TestFixture]
    public class ListBoxWithScrollBarTest : ControlsActionTest
    {
        [Test]
        public void SelectItemNotVisibleBecauseOfScrollBar()
        {
            var listBox = window.Get<ListBox>("listBoxWithVScrollBar");
            listBox.Select("0");
            ListItem selectedItem = listBox.SelectedItem;
            Assert.AreEqual("0", selectedItem.Text);
        }
    }
}