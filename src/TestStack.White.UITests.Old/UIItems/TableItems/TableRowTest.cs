using NUnit.Framework;
using White.Core.UIItems.TableItems;
using White.Core.UITests.Testing;

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

        [Test]
        public void RowData()
        {
            TableRow firstRow = rows[0];
            Assert.AreEqual("Imran", firstRow.Cells[0].Value);
            Assert.AreEqual("Pakistan", firstRow.Cells[1].Value);
            Assert.AreEqual(true.ToString(), firstRow.Cells[2].Value);

            TableRow thirdRow = rows[2];
            Assert.AreEqual("Raman Lamba", thirdRow.Cells[0].Value);
            Assert.AreEqual("India", thirdRow.Cells[1].Value);
            Assert.AreEqual(false.ToString(), thirdRow.Cells[2].Value);
        }

        [Test]
        public void GetRowAfterSortingOnAColumn()
        {
            table.Header.Columns["Name"].Click();
            table.Refresh();
            TableRow firstRow = rows[0];
            Assert.AreEqual("Imran", firstRow.Cells[0].Value);
            Assert.AreEqual("Pakistan", firstRow.Cells[1].Value);
            Assert.AreEqual(true.ToString(), firstRow.Cells[2].Value);

            TableRow thirdRow = rows[2];
            Assert.AreEqual("Raman Lamba", thirdRow.Cells[0].Value);
            Assert.AreEqual("India", thirdRow.Cells[1].Value);
            Assert.AreEqual(false.ToString(), thirdRow.Cells[2].Value);
        }

        [Test]
        public void Select()
        {
            Assert.AreEqual(true, rows[0].Select());
        }
    }
}