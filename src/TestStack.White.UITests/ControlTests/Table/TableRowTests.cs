using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UIItems.TableItems;

namespace TestStack.White.UITests.ControlTests.Table
{
    [TestFixture(WindowsFramework.WinForms)]
    public class TableRowTests : WhiteUITestBase
    {
        private UIItems.TableItems.Table table;
        private TableRows rows;

        public TableRowTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [OneTimeSetUp]
        public void Setup()
        {
            SelectDataGridTab();
            table = MainWindow.Get<UIItems.TableItems.Table>("DataGrid");
            rows = table.Rows;
        }

        [Test]
        public void RowDataTest()
        {
            var firstRow = rows[0];
            Assert.That(firstRow.Cells[0].Value, Is.EqualTo("Imran"));
            Assert.That(firstRow.Cells[1].Value, Is.EqualTo("Pakistan"));
            Assert.That(firstRow.Cells[2].Value, Is.EqualTo(true.ToString()));

            var thirdRow = rows[2];
            Assert.That(thirdRow.Cells[0].Value, Is.EqualTo("Raman Lamba"));
            Assert.That(thirdRow.Cells[1].Value, Is.EqualTo("India"));
            Assert.That(thirdRow.Cells[2].Value, Is.EqualTo(false.ToString()));
        }

        [Test]
        public void GetRowAfterSortingOnAColumnTest()
        {
            table.Header.Columns["Name"].Click();
            table.Refresh();
            var firstRow = rows[0];
            Assert.That(firstRow.Cells[0].Value, Is.EqualTo("Imran"));
            Assert.That(firstRow.Cells[1].Value, Is.EqualTo("Pakistan"));
            Assert.That(firstRow.Cells[2].Value, Is.EqualTo(true.ToString()));

            var thirdRow = rows[2];
            Assert.That(thirdRow.Cells[0].Value, Is.EqualTo("Raman Lamba"));
            Assert.That(thirdRow.Cells[1].Value, Is.EqualTo("India"));
            Assert.That(thirdRow.Cells[2].Value, Is.EqualTo(false.ToString()));
        }

        [Test]
        public void SelectTest()
        {
            Assert.That(rows[0].Select(), Is.True);
        }
    }
}