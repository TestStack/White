using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    [TestFixture, WinFormCategory]
    public class ListViewInvisibleItemTest : ControlsActionTest
    {
        private ListView listView;

        [SetUp]
        public void SetUp()
        {
            listView = Window.Get<ListView>("listView");
        }

        [Fact]
        public void SelectItemAfterScroll()
        {
            listView.Select("Key", "Video");
            Assert.Equal(1, listView.SelectedRows.Count);
            Assert.Equal("Video", listView.SelectedRows[0].Cells["Key"].Text);
        }

        [Fact]
        public void SelectItemAndThenSelectInvisibleRow()
        {
            listView.Select("Key", "Mail");
            listView.MultiSelect("Key", "Video");
            Assert.Equal(2, listView.SelectedRows.Count);
        }
    }
}