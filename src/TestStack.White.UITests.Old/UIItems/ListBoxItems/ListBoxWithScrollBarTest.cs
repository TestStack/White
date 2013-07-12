using NUnit.Framework;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UITests.Testing;

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