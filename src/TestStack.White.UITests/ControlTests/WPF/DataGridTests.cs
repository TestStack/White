using System.Collections.Generic;
using NUnit.Framework;
using TestStack.White.UITests.Infrastructure;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UIItems.WPFUIItems;

namespace TestStack.White.UITests.ControlTests.WPF
{
    public class DataGridTests : WhiteTestBase
    {
        protected ListView DataGridUnderTest { get; set; }
        protected ListView DataGridFromCustomControlUnderTest { get; set; }

        protected override void RunTest(FrameworkId framework)
        {
            DataGridUnderTest = MainWindow.Get<ListView>(SearchCriteria.ByAutomationId("DataGridControl"));
            var customControl = MainWindow.Get(SearchCriteria.ByAutomationId("CustomDataGridControl")) as UIItem;
            DataGridFromCustomControlUnderTest = customControl.Get<ListView>(SearchCriteria.ByAutomationId("DataGridControl"));

            RunTest(() => CanGetAllItems(DataGridUnderTest));
            RunTest(() => CanGetAllItems(DataGridFromCustomControlUnderTest));
            RunTest(() => CanGetCell(DataGridUnderTest));
            RunTest(() => CanGetCell(DataGridFromCustomControlUnderTest));
        }

        void CanGetAllItems(ListView dataGridUnderTest)
        {
            var rows = dataGridUnderTest.Rows;
            Assert.AreEqual(3, rows.Count);
            var row1 = rows.Get(0);
            Assert.AreEqual(3, row1.Cells.Count);
            Assert.AreEqual("1", row1.Cells[0].Text);
            Assert.AreEqual("Item1", row1.Cells[1].Text);
            StringAssert.Contains("Simple", row1.Cells[2].Text);
        }

        void CanGetCell(ListView dataGridUnderTest)
        {
            var allCells = dataGridUnderTest.Rows.Get(0).Cells;
            var header = dataGridUnderTest.Header.Columns["Contents"];
            var cell3 = allCells[header];
            var cell = dataGridUnderTest.Cell("Contents", 0);
            Assert.AreEqual("Item1", cell.Text);
            Assert.AreEqual("Item2", dataGridUnderTest.Cell("Contents", 1).Text);
            Assert.AreEqual("Item3", dataGridUnderTest.Cell("Contents", 2).Text);
        }

        protected override IEnumerable<FrameworkId> SupportedFrameworks()
        {
            yield return FrameworkId.Wpf;
        }
    }
}
