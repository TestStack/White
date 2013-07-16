using System.Collections.Generic;
using TestStack.White.UIItems;
using TestStack.White.UIItems.TableItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests.DataGrid.WinForms
{
    public class TableTest : WhiteTestBase
    {
        Table table;

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            SelectDataGridTab();
            table = MainWindow.Get<Table>("DataGrid");

            RunTest(Find);
            RunTest(TableRows);
            RunTest(SelectRowNotVisibleInitially);
            RunTest(TableHasScrollBars);
            RunTest(Columns);
            RunTest(GetRow);
            RunTest(FindAllTest);
            RunTest(IsInTop);
        }

        void Find()
        {
            table = MainWindow.Get<Table>("DataGrid");
            Assert.NotEqual(null, table);
        }

        void TableRows()
        {
            table.LogStructure();
            TableRows tableRows = table.Rows;
            Assert.True(tableRows.Count >= 13, tableRows.Count.ToString());
        }

        void SelectRowNotVisibleInitially()
        {
            TableRows rows = table.Rows;
            TableRow row = rows[rows.Count - 1];
            row.Select();
            Assert.Equal(false, row.IsOffScreen);
            row = rows[0];
            Assert.Equal(true, row.IsOffScreen);
            row.Select();
            Assert.Equal(false, row.IsOffScreen);
        }

        void TableHasScrollBars()
        {
            Assert.NotEqual(null, table.ScrollBars);
        }
        
        void Columns()
        {
            Assert.Equal(5, table.Header.Columns.Count);
        }

        void GetRow()
        {
            Assert.Equal("Imran", table.Row("Name", "Imran").Cells[0].Value);
        }

        void FindAllTest()
        {
            TableRows rows = table.Rows;
            rows[1].Cells[0].Value = "Imran";
            Assert.Equal("Imran", table.FindAll("Name", "Imran")[0].Cells[0].Value);
            Assert.Equal("Imran", table.FindAll("Name", "Imran")[1].Cells[0].Value);
        }

        void IsInTop()
        {
            Assert.Equal(true, ((TableVerticalScrollOffset)table).IsOnTop);
            table.Rows[table.Rows.Count - 1].Select();
            Assert.Equal(false, ((TableVerticalScrollOffset)table).IsOnTop);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.WinForms;
        }
    }
}