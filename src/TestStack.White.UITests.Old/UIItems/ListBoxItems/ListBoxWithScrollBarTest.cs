using NUnit.Framework;
using White.Core.UIItems.ListBoxItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems.ListBoxItems
{
    public class ListBoxWithScrollBarTest : ControlsActionTest
    {
        [Fact]
        public void SelectItemNotVisibleBecauseOfScrollBar()
        {
            var listBox = Window.Get<ListBox>("listBoxWithVScrollBar");
            listBox.Select("0");
            ListItem selectedItem = listBox.SelectedItem;
            Assert.Equal("0", selectedItem.Text);
        }
    }
}