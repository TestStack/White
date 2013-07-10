using NUnit.Framework;
using White.Core.UIItems.TableItems;

namespace White.Core.UITests.UIItems.TableItems
{
    [WinFormCategory]
    public class TableTest : AbstractTableTest
    {
        [Fact]
        public void Columns()
        {
            Assert.Equal(5, table.Header.Columns.Count);
        }

        [Fact]
        public void GetRow()
        {
            Assert.Equal("Imran", table.Row("Name", "Imran").Cells[0].Value);
        }

        [Fact]
        public void FindAllTest()
        {
            TableRows rows = table.Rows;
            rows[1].Cells[0].Value = "Imran";
            Assert.Equal("Imran", table.FindAll("Name", "Imran")[0].Cells[0].Value);
            Assert.Equal("Imran", table.FindAll("Name", "Imran")[1].Cells[0].Value);
        }
    }
}