using NUnit.Framework;
using TestStack.White.UIItems.TableItems;
using TestStack.White.UITests.Testing;

namespace White.Core.UITests.UIItems.TableItems
{
    [TestFixture, WinFormCategory]
    public abstract class AbstractTableTest : ControlsActionTest
    {
        protected Table table;

        protected override void TestFixtureSetUp()
        {
            table = Window.Get<Table>("people");
        }

        [Fact]
        public void Find()
        {
            Assert.NotEqual(null, table);
        }

        [Fact]
        public void TableRows()
        {
            table.LogStructure();
            TableRows tableRows = table.Rows;
            Assert.Equal(true, tableRows.Count >= 13, tableRows.Count.ToString());
        }

        [Fact]
        public void SelectRowNotVisibleInitially()
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

        [Fact]
        public void TableHasScrollBars()
        {
            Assert.NotEqual(null, table.ScrollBars);
        }
    }
}