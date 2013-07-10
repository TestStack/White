using System.Windows.Automation;
using NUnit.Framework;
using White.Core.UIItems;
using White.Core.UIItems.ListViewItems;
using White.Core.UITests.Testing;
using Xunit;

namespace White.Core.UITests.UIItems
{
    [TestFixture, WinFormCategory, WPFCategory]
    public class ListViewTest : ControlsActionTest
    {
        private ListView listView;

        protected override void TestFixtureSetUp()
        {
            listView = Window.Get<ListView>("listView");
        }

        [Fact]
        public void SelectRow()
        {
            listView.Select(0);
            ListViewRow firstRow = listView.Rows[0];
            Assert.Equal(true, firstRow.IsSelected);
            Assert.Equal("listView item selected - " + 0, Window.Get<Label>("result").Text);
            listView.Select(1);
            ListViewRow secondRow = listView.Rows[1];
            Assert.Equal(true, secondRow.IsSelected);
        }

        [Fact]
        public void SelectedRow()
        {
            listView.Select(0);
            ListViewRow listViewRow = listView.SelectedRows[0];
            Assert.Equal("Search", listViewRow.Cells["Key"].Text);
        }

        [Fact]
        public void Select_based_on_cell()
        {
            listView.Select("Key", "Mail");
            Assert.Equal("Mail", listView.SelectedRows[0].Cells["Key"].Text);
        }

        [Fact]
        public void Columns()
        {
            ListViewColumns columns = listView.Header.Columns;
            Assert.Equal(3, columns.Count);
            Assert.Equal("Key", columns[1].Name);
            Assert.Equal("Value", columns[2].Name);
        }

        [Fact]
        public void RowCount()
        {
            Assert.Equal(6, listView.Rows.Count);
        }

        [Fact]
        public void CellCount()
        {
            ListViewRow row = listView.Rows[0];
            Assert.Equal(2, row.Cells.Count);
        }

        [Fact]
        public void CellText()
        {
            ListViewRow first = listView.Rows[0];
            Assert.Equal("Search", first.Cells[0].Text);
            Assert.Equal("Google", first.Cells[1].Text);
            ListViewRow second = listView.Rows[1];
            Assert.Equal("Mail", second.Cells[0].Text);
            Assert.Equal("GMail", second.Cells[1].Text);
        }

        [Fact]
        public void SelectedRows()
        {
            listView.Rows[5].Select();
            listView.Rows[0].Select();
            ListViewRows rows = listView.SelectedRows;
            Assert.Equal(1, rows.Count);
        }

        [Fact]
        public void MultiSelect()
        {
            listView.Rows[0].Select();
            listView.Rows[1].MultiSelect();
            Assert.Equal(2, listView.SelectedRows.Count);
        }

        [Fact(Skip = "Needs list view to select full row, which break other listview test")]
        public void FindModalWindowAppearingOnDoubleClick()
        {
            ListViewRows rows = listView.Rows;
            rows[0].DoubleClick();
            CloseModal(Window);
        }
    }
}