using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    [TestFixture, WinFormCategory]
    public class WinFormListViewTest : ControlsActionTest
    {
        [Test]
        public void TryUnSelectAll()
        {
            var listView = window.Get<ListView>("listView");
            listView.Rows[0].Select();
            Assert.AreEqual(1, listView.SelectedRows.Count);
            listView.TryUnSelectAll();
            Assert.AreEqual(0, listView.SelectedRows.Count);
        }
    }
}