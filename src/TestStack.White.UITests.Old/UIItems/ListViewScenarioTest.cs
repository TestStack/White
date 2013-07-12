using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UITests.Testing;

namespace White.Core.UITests.UIItems
{
    [TestFixture, WinFormCategory]
    public class ListViewScenarioTest : ControlsActionTest
    {
        [Fact]
        public void Select()
        {
            ListView listView = Window.Get<ListView>("listViewForScenarioTest");
            listView.Select("", "foo");
            ListViewRows rows = listView.SelectedRows;
            Assert.Equal(1, rows.Count);
            Assert.Equal("foo", rows[0].Cells[0].Text);
        }
    }
}