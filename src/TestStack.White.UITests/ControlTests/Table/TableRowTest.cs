using System.Collections.Generic;
using TestStack.White.UIItems;
using TestStack.White.UIItems.TableItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests.DataGrid.WinForms
{
    public class TableRowTest : WhiteTestBase
    {
        Table table;
        TableRows rows;

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            SelectDataGridTab();
            table = MainWindow.Get<Table>("DataGrid");
            rows = table.Rows;

            RunTest(RowData);
            RunTest(GetRowAfterSortingOnAColumn);
            RunTest(Select);
        }

        void RowData()
        {
            TableRow firstRow = rows[0];
            Assert.Equal("Imran", firstRow.Cells[0].Value);
            Assert.Equal("Pakistan", firstRow.Cells[1].Value);
            Assert.Equal(true.ToString(), firstRow.Cells[2].Value);

            TableRow thirdRow = rows[2];
            Assert.Equal("Raman Lamba", thirdRow.Cells[0].Value);
            Assert.Equal("India", thirdRow.Cells[1].Value);
            Assert.Equal(false.ToString(), thirdRow.Cells[2].Value);
        }

        void GetRowAfterSortingOnAColumn()
        {
            table.Header.Columns["Name"].Click();
            table.Refresh();
            TableRow firstRow = rows[0];
            Assert.Equal("Imran", firstRow.Cells[0].Value);
            Assert.Equal("Pakistan", firstRow.Cells[1].Value);
            Assert.Equal(true.ToString(), firstRow.Cells[2].Value);

            TableRow thirdRow = rows[2];
            Assert.Equal("Raman Lamba", thirdRow.Cells[0].Value);
            Assert.Equal("India", thirdRow.Cells[1].Value);
            Assert.Equal(false.ToString(), thirdRow.Cells[2].Value);
        }

        void Select()
        {
            Assert.True(rows[0].Select());
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.WinForms;
        }
    }
}