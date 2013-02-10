using System.Threading;
using NUnit.Framework;
using White.Core.UIItems.ListBoxItems;
using White.Core.UIItems.MenuItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems.MenuItems
{
    [TestFixture]
    public class PopUpMenuTest : ControlsActionTest
    {
        [Test]
        public void GetPopupMenuItems()
        {
            Window.Get<ListBox>("listBox").RightClick();
            PopUpMenu popup = Window.Popup;
            Assert.AreEqual(1, popup.Items.Count);
        }

        [Test]
        public void ClickOnPopupMenu()
        {
            Window.Get<ListBox>("listBox").RightClick();
            Assert.AreEqual(true, Window.HasPopup());
            Menu menu = Window.PopupMenu("Show Films");
            menu.Click();
            AssertResultLabelText("All good films");
        }

        [Test]
        public void ClickOnNestedMenu()
        {
            Window.Get<ListBox>("listBoxWithVScrollBar").RightClick();
            Window.PopupMenu("Root", "Level1", "Level2").Click();
            AssertResultLabelText("Level2Click");
        }
    }
}