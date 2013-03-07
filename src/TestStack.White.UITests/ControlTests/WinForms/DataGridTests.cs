using System.Collections.Generic;
using NUnit.Framework;
using TestStack.White.UITests.Infrastructure;
using White.Core.UIItems.Finders;
using White.Core.UIItems.TableItems;

namespace TestStack.White.UITests.ControlTests.WinForms
{
    public class DataGridTests : WhiteTestBase
    {
        protected Table DataGridUnderTest { get; set; }

        protected override void RunTest(FrameworkId framework)
        {
            DataGridUnderTest = MainWindow.Get<Table>(SearchCriteria.ByAutomationId("DataGridControl"));
            RunTest(CanGetAllItems);
        }

        void CanGetAllItems()
        {
            var rows = DataGridUnderTest.Rows;
            Assert.AreEqual(3, rows.Count);
            var row1 = rows[0];
            Assert.AreEqual(3, row1.Cells.Count);
            Assert.AreEqual("1", row1.Cells[0].Value);
            Assert.AreEqual("Item1", row1.Cells[1].Value);
            StringAssert.Contains("Simple", (string)row1.Cells[2].Value);
        }

        protected override IEnumerable<FrameworkId> SupportedFrameworks()
        {
            yield return FrameworkId.Winforms;
        }
    }
}
