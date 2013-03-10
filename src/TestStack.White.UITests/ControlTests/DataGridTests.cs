using System.Collections.Generic;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TableItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests
{
    public class DataGridTests : WhiteTestBase
    {
        protected ListView DataGridWpfUnderTest { get; set; }
        protected Table DataGridWinFormsUnderTest { get; set; }

        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            SelectDataGridTab();
            if (framework == WindowsFramework.Wpf)
            {
                DataGridWpfUnderTest = MainWindow.Get<ListView>(SearchCriteria.ByAutomationId("DataGridControl"));
                RunTest(CanGetAllItemsWpf);
                RunTest(CanGetCellWpf);
            }
            else if (framework == WindowsFramework.WinForms)
            {
                DataGridWinFormsUnderTest = MainWindow.Get<Table>(SearchCriteria.ByAutomationId("DataGridControl"));
                RunTest(CanGetAllItemsWinforms);
            }
        }

        void CanGetAllItemsWpf()
        {
            var rows = DataGridWpfUnderTest.Rows;
            Assert.Equal(3, rows.Count);
            var row1 = rows.Get(0);
            Assert.Equal(3, row1.Cells.Count);
            Assert.Equal("1", row1.Cells[0].Text);
            Assert.Equal("Item1", row1.Cells[1].Text);
            Assert.Contains("Simple", row1.Cells[2].Text);
        }

        void CanGetCellWpf()
        {
            Assert.Equal("Item1", DataGridWpfUnderTest.Cell("Contents", 0).Text);
            Assert.Equal("Item2", DataGridWpfUnderTest.Cell("Contents", 1).Text);
            Assert.Equal("Item3", DataGridWpfUnderTest.Cell("Contents", 2).Text);
        }

        void CanGetAllItemsWinforms()
        {
            var rows = DataGridWinFormsUnderTest.Rows;
            Assert.Equal(3, rows.Count);
            var row1 = rows[0];
            Assert.Equal(3, row1.Cells.Count);
            Assert.Equal("1", row1.Cells[0].Value);
            Assert.Equal("Item1", row1.Cells[1].Value);
            Assert.Contains("Simple", (string)row1.Cells[2].Value);
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.WinForms;
            yield return WindowsFramework.Wpf;
        }
    }
}
