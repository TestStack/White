using NUnit.Framework;
using White.UnitTests.Core.Testing;

namespace White.Core.UIItems.TableItems
{
    [TestFixture, WinFormCategory]
    public class TableRowTest : ControlsActionTest
    {
        private Table table;
        private TableRows rows;

        protected override void TestFixtureSetUp()
        {
            table = window.Get<Table>("people");
            rows = table.Rows;
        }

        [Test]
        public void RowData()
        {
            rows[0].LogStructure();
            Assert.AreEqual("Imran", rows[0].Cells[0].Value);
            Assert.AreEqual("Pakistan", rows[0].Cells[1].Value);
            Assert.AreEqual(true.ToString(), rows[0].Cells[2].Value);

            Assert.AreEqual("Raman Lamba", rows[2].Cells[0].Value);
            Assert.AreEqual("India", rows[2].Cells[1].Value);
            Assert.AreEqual(false.ToString(), rows[2].Cells[2].Value);
        }

        [Test]
        public void Select()
        {
            Assert.AreEqual(true, rows[0].Select());
        }
    }
}