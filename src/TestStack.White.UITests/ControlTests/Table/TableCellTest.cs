using System.Collections.Generic;
using TestStack.White.UIItems;
using TestStack.White.UIItems.TableItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests.DataGrid.WinForms
{
    public class TableCellTest : WhiteTestBase
    {
        TableRow row;
        Table table;

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            SelectDataGridTab();
            table = MainWindow.Get<Table>("DataGrid");
            TableRows rows = table.Rows;
            row = rows[0];

            RunTest(SetTextCellValue);
            RunTest(GetEmptyValue);
            RunTest(SetCheckBoxCellValue);
            RunTest(SetComboBoxCellValue);
            RunTest(TextOnButtonCell);
            RunTest(Click);
        }

        void SetTextCellValue()
        {
            TableCell cell = row.Cells[0];
            Assert.Equal("Imran", cell.Value);
            cell.Value = "Mudassar";
            Assert.Equal("Mudassar", cell.Value);
        }

        void GetEmptyValue()
        {
            TableCell cell = table.Rows[3].Cells[0];
            cell.Value = string.Empty;
            Assert.Equal(string.Empty, cell.Value);
        }

        void SetCheckBoxCellValue()
        {
            Assert.Equal(true.ToString(), row.Cells[2].Value);
            row.Cells[2].Value = true;
            Assert.Equal(true.ToString(), row.Cells[2].Value);
            row.Cells[2].Value = false;
            Assert.Equal(false.ToString(), row.Cells[2].Value);
        }

        void SetComboBoxCellValue()
        {
            Assert.Equal("Pakistan", row.Cells[1].Value);
            row.Cells[1].Value = "India";
            Assert.Equal("India", row.Cells[1].Value);
        }

        void TextOnButtonCell()
        {
            Assert.Equal("Show", row.Cells[3].Value);
        }

        void Click()
        {
            row.Cells[1].Click();
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.WinForms;
        }
    }
}