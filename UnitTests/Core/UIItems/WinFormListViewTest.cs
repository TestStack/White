using NUnit.Framework;
using White.UnitTests.Core.Testing;

namespace White.Core.UIItems
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