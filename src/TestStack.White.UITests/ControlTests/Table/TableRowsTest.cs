using System.Collections.Generic;
using TestStack.White.UIItems;
using TestStack.White.UIItems.TableItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests.DataGrid.WinForms
{
    public class TableRowsTest : WhiteTestBase
    {
        Table table;

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            SelectDataGridTab();
            table = MainWindow.Get<Table>("DataGrid");

            RunTest(GetRowTest);
            RunTest(GetMultipleRowsTest);
        }

        void GetRowTest()
        {
            TableRows rows = table.Rows;
            Assert.Equal("Imran", rows.Get("Name", "Imran").Cells[0].Value);
        }

        void GetMultipleRowsTest()
        {
            TableRows rows = table.Rows;
            rows[1].Cells[0].Value = "Imran";
            Assert.Equal("Imran", rows.GetMultipleRows("Name", "Imran")[0].Cells[0].Value);
            Assert.Equal("Imran", rows.GetMultipleRows("Name", "Imran")[1].Cells[0].Value);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.WinForms;
        }
    }
}