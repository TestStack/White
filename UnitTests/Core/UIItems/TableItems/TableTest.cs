using NUnit.Framework;

namespace White.Core.UIItems.TableItems
{
    [WinFormCategory]
    public class TableTest : AbstractTableTest
    {
        [Test]
        public void Columns()
        {
            Assert.AreEqual(5, table.Header.Columns.Count);
        }

        [Test]
        public void GetRow()
        {
            Assert.AreEqual("Imran", table.Row("Name", "Imran").Cells[0].Value);
        }

        [Test]
        public void FindAllTest()
        {
            TableRows rows = table.Rows;
            rows[1].Cells[0].Value = "Imran";
            Assert.AreEqual("Imran", table.FindAll("Name", "Imran")[0].Cells[0].Value);
            Assert.AreEqual("Imran", table.FindAll("Name", "Imran")[1].Cells[0].Value);
        }
    }
}