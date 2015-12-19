using NUnit.Framework;
using System;
using TestStack.White.UIItems;
using TestStack.White.UIItems.TableItems;

namespace TestStack.White.UITests.ControlTests.Table
{
    [TestFixture(WindowsFramework.WinForms)]
    public class TableCellTests : WhiteUITestBase
    {
        private UIItems.TableItems.Table table;
        private TableRow row;

        public TableCellTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [OneTimeSetUp]
        public void Setup()
        {
            SelectDataGridTab();
            table = MainWindow.Get<UIItems.TableItems.Table>("DataGrid");
            var rows = table.Rows;
            row = rows[0];
        }

        [Test]
        public void SetTextCellValueTest()
        {
            var cell = row.Cells[0];
            Assert.That(cell.Value, Is.EqualTo("Imran"));
            cell.Value = "Mudassar";
            Assert.That(cell.Value, Is.EqualTo("Mudassar"));
        }

        [Test]
        public void GetEmptyValueTest()
        {
            var cell = table.Rows[3].Cells[0];
            cell.Value = String.Empty;
            Assert.That(cell.Value, Is.Empty);
        }

        [Test]
        public void SetCheckBoxCellValueTest()
        {
            Assert.That(row.Cells[2].Value, Is.EqualTo(true.ToString()));
            row.Cells[2].Value = true;
            Assert.That(row.Cells[2].Value, Is.EqualTo(true.ToString()));
            row.Cells[2].Value = false;
            Assert.That(row.Cells[2].Value, Is.EqualTo(false.ToString()));
        }

        [Test]
        public void SetComboBoxCellValueTest()
        {
            Assert.That(row.Cells[1].Value, Is.EqualTo("Pakistan"));
            row.Cells[1].Value = "India";
            Assert.That(row.Cells[1].Value, Is.EqualTo("India"));
        }

        [Test]
        public void TextOnButtonCellTest()
        {
            Assert.That(row.Cells[3].Value, Is.EqualTo("Show"));
        }

        [Test]
        public void ClickTest()
        {
            Assert.That(() => { row.Cells[1].Click(); }, Throws.Nothing);
        }
    }
}