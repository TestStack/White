using System.Threading;
using NUnit.Framework;
using White.Core.UIItems.ListBoxItems;
using White.Core.UIItems.MenuItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems.MenuItems
{
    public class PopUpMenuTest : ControlsActionTest
    {
        [Fact]
        public void GetPopupMenuItems()
        {
            Window.Get<ListBox>("listBox").RightClick();
            PopUpMenu popup = Window.Popup;
            Assert.Equal(1, popup.Items.Count);
        }

        [Fact]
        public void ClickOnPopupMenu()
        {
            Window.Get<ListBox>("listBox").RightClick();
            Assert.Equal(true, Window.HasPopup());
            Menu menu = Window.PopupMenu("Show Films");
            menu.Click();
            AssertResultLabelText("All good films");
        }

        [Fact]
        public void ClickOnNestedMenu()
        {
            Window.Get<ListBox>("listBoxWithVScrollBar").RightClick();
            Window.PopupMenu("Root", "Level1", "Level2").Click();
            AssertResultLabelText("Level2Click");
        }
    }
}