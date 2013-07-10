using NUnit.Framework;
using White.Core.UIItems.TableItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems.TableItems
{
    [TestFixture, WinFormCategory]
    public class TableRowsTest : ControlsActionTest
    {
        private Table table;

        protected override void TestFixtureSetUp()
        {
            table = Window.Get<Table>("people");
        }

        [Fact]
        public void GetRowTest()
        {
            TableRows rows = table.Rows;
            Assert.Equal("Imran", rows.Get("Name", "Imran").Cells[0].Value);
        }

        [Fact]
        public void GetMultipleRowsTest()
        {
            TableRows rows = table.Rows;
            rows[1].Cells[0].Value = "Imran";
            Assert.Equal("Imran", rows.GetMultipleRows("Name", "Imran")[0].Cells[0].Value);
            Assert.Equal("Imran", rows.GetMultipleRows("Name", "Imran")[1].Cells[0].Value);
        }
    }
}