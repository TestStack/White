using NUnit.Framework;
using TestStack.White.UIItems;

namespace TestStack.White.UITests.ControlTests.Table
{
    [TestFixture(WindowsFramework.WinForms)]
    public class TableRowsTests : WhiteUITestBase
    {
        private UIItems.TableItems.Table table;

        public TableRowsTests(WindowsFramework framework)
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
        public void GetRowTest()
        {
            var rows = table.Rows;
            Assert.That(rows.Get("Name", "Imran").Cells[0].Value, Is.EqualTo("Imran"));
        }

        [Test]
        public void GetMultipleRowsTest()
        {
            var rows = table.Rows;
            rows[1].Cells[0].Value = "Imran";
            Assert.That(rows.GetMultipleRows("Name", "Imran")[0].Cells[0].Value, Is.EqualTo("Imran"));
            Assert.That(rows.GetMultipleRows("Name", "Imran")[1].Cells[0].Value, Is.EqualTo("Imran"));
        }
    }
}