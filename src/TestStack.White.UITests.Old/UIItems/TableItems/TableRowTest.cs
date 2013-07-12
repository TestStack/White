using NUnit.Framework;
using TestStack.White.UIItems.TableItems;
using TestStack.White.UITests.Testing;

namespace White.Core.UITests.UIItems.TableItems
{
    [TestFixture, WinFormCategory]
    public class TableRowTest : ControlsActionTest
    {
        private Table table;
        private TableRows rows;

        protected override void TestFixtureSetUp()
        {
            table = Window.Get<Table>("people");
            rows = table.Rows;
        }

        [Fact]
        public void RowData()
        {
            TableRow firstRow = rows[0];
            Assert.Equal("Imran", firstRow.Cells[0].Value);
            Assert.Equal("Pakistan", firstRow.Cells[1].Value);
            Assert.Equal(true.ToString(), firstRow.Cells[2].Value);

            TableRow thirdRow = rows[2];
            Assert.Equal("Raman Lamba", thirdRow.Cells[0].Value);
            Assert.Equal("India", thirdRow.Cells[1].Value);
            Assert.Equal(false.ToString(), thirdRow.Cells[2].Value);
        }

        [Fact]
        public void GetRowAfterSortingOnAColumn()
        {
            table.Header.Columns["Name"].Click();
            table.Refresh();
            TableRow firstRow = rows[0];
            Assert.Equal("Imran", firstRow.Cells[0].Value);
            Assert.Equal("Pakistan", firstRow.Cells[1].Value);
            Assert.Equal(true.ToString(), firstRow.Cells[2].Value);

            TableRow thirdRow = rows[2];
            Assert.Equal("Raman Lamba", thirdRow.Cells[0].Value);
            Assert.Equal("India", thirdRow.Cells[1].Value);
            Assert.Equal(false.ToString(), thirdRow.Cells[2].Value);
        }

        [Fact]
        public void Select()
        {
            Assert.Equal(true, rows[0].Select());
        }
    }
}