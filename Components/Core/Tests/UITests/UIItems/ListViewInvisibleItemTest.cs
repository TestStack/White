using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    [TestFixture, WinFormCategory]
    public class ListViewInvisibleItemTest : ControlsActionTest
    {
        private ListView listView;

        [SetUp]
        public void SetUp()
        {
            listView = window.Get<ListView>("listView");
        }

        [Test]
        public void SelectItemAfterScroll()
        {
            listView.Select("Key", "Video");
            Assert.AreEqual(1, listView.SelectedRows.Count);
            Assert.AreEqual("Video", listView.SelectedRows[0].Cells["Key"].Text);
        }

        [Test]
        public void SelectItemAndThenSelectInvisibleRow()
        {
            listView.Select("Key", "Mail");
            listView.MultiSelect("Key", "Video");
            Assert.AreEqual(2, listView.SelectedRows.Count);
        }
    }
}