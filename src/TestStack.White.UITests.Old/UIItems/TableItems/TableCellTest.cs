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

        [Fact]
        public void SetTextCellValue()
        {
            TableCell cell = row.Cells[0];
            Assert.Equal("Imran", cell.Value);
            cell.Value = "Mudassar";
            Assert.Equal("Mudassar", cell.Value);
        }

        [Fact]
        public void GetEmptyValue()
        {
            TableCell cell = table.Rows[3].Cells[0];
            cell.Value = string.Empty;
            Assert.Equal(string.Empty, cell.Value);
        }

        [Fact]
        public void SetCheckBoxCellValue()
        {
            Assert.Equal(true.ToString(), row.Cells[2].Value);
            row.Cells[2].Value = true;
            Assert.Equal(true.ToString(), row.Cells[2].Value);
            row.Cells[2].Value = false;
            Assert.Equal(false.ToString(), row.Cells[2].Value);
        }

        [Fact]
        public void SetComboBoxCellValue()
        {
            Assert.Equal("Pakistan", row.Cells[1].Value);
            row.Cells[1].Value = "India";
            Assert.Equal("India", row.Cells[1].Value);
        }

        [Fact]
        public void TextOnButtonCell()
        {
            Assert.Equal("Show", row.Cells[3].Value);
        }

        //TODO: Why does clicking on cell number 3 clicks on cell number 1
        [Fact]
        public void Click()
        {
            row.Cells[1].Click();
        }
    }
}