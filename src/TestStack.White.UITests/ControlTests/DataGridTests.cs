using System.Collections.Generic;
using NUnit.Framework;
using TestStack.White.UITests.Infrastructure;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UIItems.TableItems;

namespace TestStack.White.UITests.ControlTests
{
    public class DataGridTests : WhiteTestBase
    {
        protected ListView DataGridWpfUnderTest { get; set; }
        protected Table DataGridWinFormsUnderTest { get; set; }

        protected override void RunTest(FrameworkId framework)
        {
            if (framework == FrameworkId.Wpf)
            {
                DataGridWpfUnderTest = MainWindow.Get<ListView>(SearchCriteria.ByAutomationId("DataGridControl"));
                RunTest(CanGetAllItemsWpf);
                RunTest(CanGetCellWpf);
            }
            else if (framework == FrameworkId.Winforms)
            {
                DataGridWinFormsUnderTest = MainWindow.Get<Table>(SearchCriteria.ByAutomationId("DataGridControl"));
                RunTest(CanGetAllItemsWinforms);
            }
        }

        void CanGetAllItemsWpf()
        {
            var rows = DataGridWpfUnderTest.Rows;
            Assert.AreEqual(3, rows.Count);
            var row1 = rows.Get(0);
            Assert.AreEqual(3, row1.Cells.Count);
            Assert.AreEqual("1", row1.Cells[0].Text);
            Assert.AreEqual("Item1", row1.Cells[1].Text);
            StringAssert.Contains("Simple", row1.Cells[2].Text);
        }

        void CanGetCellWpf()
        {
            Assert.AreEqual("Item1", DataGridWpfUnderTest.Cell("Contents", 0).Text);
            Assert.AreEqual("Item2", DataGridWpfUnderTest.Cell("Contents", 1).Text);
            Assert.AreEqual("Item3", DataGridWpfUnderTest.Cell("Contents", 2).Text);
        }

        void CanGetAllItemsWinforms()
        {
            var rows = DataGridWinFormsUnderTest.Rows;
            Assert.AreEqual(3, rows.Count);
            var row1 = rows[0];
            Assert.AreEqual(3, row1.Cells.Count);
            Assert.AreEqual("1", row1.Cells[0].Value);
            Assert.AreEqual("Item1", row1.Cells[1].Value);
            StringAssert.Contains("Simple", (string)row1.Cells[2].Value);
        }

        protected override IEnumerable<FrameworkId> SupportedFrameworks()
        {
            return AllFrameworks();
        }
    }
}
