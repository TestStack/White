using NUnit.Framework;
using White.Core.UIItems.ListBoxItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems.ListBoxItems
{
    [TestFixture]
    public class ListBoxTest : ControlsActionTest
    {
        private ListBox listBox;

        protected override void TestFixtureSetUp()
        {
            listBox = window.Get<ListBox>("chequedListBox");
        }

        [Test]
        public void FindListBox()
        {
            Assert.AreNotEqual(null, listBox);
        }

        [Test]
        public void Items()
        {
            Assert.AreEqual(2, listBox.Items.Count);
        }

        [Test]
        public void IsSelected()
        {
            Assert.AreEqual(false, listBox.IsSelected("Bill Gates"));
        }

        [Test]
        public void Select()
        {
            listBox.Select("Bill Gates");
            Assert.AreEqual(true, listBox.IsSelected("Bill Gates"));
        }

        [Test]
        public void UnSelect()
        {
            listBox.Select("Bill Gates");
            Assert.AreEqual(true, listBox.IsSelected("Bill Gates"));
            listBox.Select("Narayan Murthy");
            Assert.AreEqual(false, listBox.IsSelected("Bill Gates"));
        }
    }

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