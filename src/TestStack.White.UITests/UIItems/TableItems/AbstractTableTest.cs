using NUnit.Framework;
using White.Core.UIItems.TableItems;
using White.Core.UITests.Testing;

namespace White.Core.UITests.UIItems.TableItems
{
    [TestFixture, WinFormCategory]
    public abstract class AbstractTableTest : ControlsActionTest
    {
        protected Table table;

        protected override void TestFixtureSetUp()
        {
            table = window.Get<Table>("people");
        }

        [Test]
        public void Find()
        {
            Assert.AreNotEqual(null, table);
        }

        [Test]
        public void TableRows()
        {
            table.LogStructure();
            TableRows tableRows = table.Rows;
            Assert.AreEqual(true, tableRows.Count >= 13, tableRows.Count.ToString());
        }

        [Test]
        public void SelectRowNotVisibleInitially()
        {
            TableRows rows = table.Rows;
            TableRow row = rows[rows.Count - 1];
            row.Select();
            Assert.AreEqual(false, row.IsOffScreen);
            row = rows[0];
            Assert.AreEqual(true, row.IsOffScreen);
            row.Select();
            Assert.AreEqual(false, row.IsOffScreen);
        }

        [Test]
        public void TableHasScrollBars()
        {
            Assert.AreNotEqual(null, table.ScrollBars);
        }
    }
}