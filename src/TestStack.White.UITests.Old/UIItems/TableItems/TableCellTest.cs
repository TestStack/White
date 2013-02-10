using NUnit.Framework;
using White.Core.UIItems.TableItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems.TableItems
{
    [TestFixture, WinFormCategory]
    public class TableCellTest : ControlsActionTest
    {
        private TableRow row;
        private Table table;

        protected override void TestFixtureSetUp()
        {
            table = Window.Get<Table>("people");
        }

        [SetUp]
        public void SetUp()
        {
            TableRows rows = table.Rows;
            row = rows[0];
            row.Cells[0].Value = "Imran";
        }

        [Test]
        public void SetTextCellValue()
        {
            TableCell cell = row.Cells[0];
            Assert.AreEqual("Imran", cell.Value);
            cell.Value = "Mudassar";
            Assert.AreEqual("Mudassar", cell.Value);
        }

        [Test]
        public void GetEmptyValue()
        {
            TableCell cell = table.Rows[3].Cells[0];
            cell.Value = string.Empty;
            Assert.AreEqual(string.Empty, cell.Value);
        }

        [Test]
        public void SetCheckBoxCellValue()
        {
            Assert.AreEqual(true.ToString(), row.Cells[2].Value);
            row.Cells[2].Value = true;
            Assert.AreEqual(true.ToString(), row.Cells[2].Value);
            row.Cells[2].Value = false;
            Assert.AreEqual(false.ToString(), row.Cells[2].Value);
        }

        [Test]
        public void SetComboBoxCellValue()
        {
            Assert.AreEqual("Pakistan", row.Cells[1].Value);
            row.Cells[1].Value = "India";
            Assert.AreEqual("India", row.Cells[1].Value);
        }

        [Test]
        public void TextOnButtonCell()
        {
            Assert.AreEqual("Show", row.Cells[3].Value);
        }

        //TODO: Why does clicking on cell number 3 clicks on cell number 1
        [Test]
        public void Click()
        {
            row.Cells[1].Click();
        }
    }
}