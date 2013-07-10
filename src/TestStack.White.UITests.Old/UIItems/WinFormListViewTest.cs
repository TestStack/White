using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    [TestFixture, WinFormCategory]
    public class WinFormListViewTest : ControlsActionTest
    {
        [Fact]
        public void TryUnSelectAll()
        {
            var listView = Window.Get<ListView>("listView");
            listView.Rows[0].Select();
            Assert.Equal(1, listView.SelectedRows.Count);
            listView.TryUnSelectAll();
            Assert.Equal(0, listView.SelectedRows.Count);
        }
    }
}