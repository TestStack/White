using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UIItems.TableItems;

namespace TestStack.White.UITests.ControlTests.Table
{
    [TestFixture(WindowsFramework.WinForms)]
    public class TableTests : WhiteUITestBase
    {
        private UIItems.TableItems.Table table;

        public TableTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [OneTimeSetUp]
        public void Setup()
        {
            SelectDataGridTab();
            table = MainWindow.Get<UIItems.TableItems.Table>("DataGrid");
        }

        [Test]
        public void FindTest()
        {
            table = MainWindow.Get<UIItems.TableItems.Table>("DataGrid");
            Assert.That(table, Is.Not.Null);
        }

        [Test]
        public void TableRowsTest()
        {
            table.LogStructure();
            var tableRows = table.Rows;
            Assert.That(tableRows, Has.Count.GreaterThanOrEqualTo(13));
        }

        [Test]
        public void SelectRowNotVisibleInitiallyTest()
        {
            var rows = table.Rows;
            var row = rows[rows.Count - 1];
            row.Select();
            Assert.That(row.IsOffScreen, Is.False);
            row = rows[0];
            Assert.That(row.IsOffScreen, Is.True);
            row.Select();
            Assert.That(row.IsOffScreen, Is.False);
        }

        [Test]
        public void TableHasScrollBarsTest()
        {
            Assert.That(table.ScrollBars, Is.Not.Null);
        }

        [Test]
        public void ColumnsTest()
        {
            Assert.That(table.Header.Columns, Has.Count.EqualTo(5));
        }

        [Test]
        public void GetRowTest()
        {
            Assert.That(table.Row("Name", "Imran").Cells[0].Value, Is.EqualTo("Imran"));
        }

        [Test]
        public void FindAllTest()
        {
            var rows = table.Rows;
            rows[1].Cells[0].Value = "Imran";
            Assert.That(table.FindAll("Name", "Imran")[0].Cells[0].Value, Is.EqualTo("Imran"));
            Assert.That(table.FindAll("Name", "Imran")[1].Cells[0].Value, Is.EqualTo("Imran"));
        }

        [Test]
        public void IsInTopTest()
        {
            Assert.That(((ITableVerticalScrollOffset)table).IsOnTop, Is.True);
            table.Rows[table.Rows.Count - 1].Select();
            Assert.That(((ITableVerticalScrollOffset)table).IsOnTop, Is.False);
        }
    }
}