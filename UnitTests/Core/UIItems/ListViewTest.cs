using NUnit.Framework;
using White.Core.Testing;
using White.Core.UIItems.ListViewItems;

namespace White.Core.UIItems
{
    [TestFixture, WinFormCategory, WPFCategory]
    public class ListViewTest : ControlsActionTest
    {
        private ListView listView;

        protected override void TestFixtureSetUp()
        {
            listView = window.Get<ListView>("listView");
        }

        [Test]
        public void SelectRow()
        {
            listView.Select(0);
            ListViewRow firstRow = listView.Rows[0];
            Assert.AreEqual(true, firstRow.IsSelected);
            Assert.AreEqual("listView item selected - " + 0, window.Get<Label>("result").Text);
            listView.Select(1);
            ListViewRow secondRow = listView.Rows[1];
            Assert.AreEqual(true, secondRow.IsSelected);
        }

        [Test]
        public void SelectedRow()
        {
            listView.Select(0);
            ListViewRow listViewRow = listView.SelectedRows[0];
            Assert.AreEqual("Search", listViewRow.Cells["Key"].Text);
        }

        [Test]
        public void Select_based_on_cell()
        {
            listView.Select("Key", "Mail");
            Assert.AreEqual("Mail", listView.SelectedRows[0].Cells["Key"].Text);
        }

        [Test]
        public void Columns()
        {
            ListViewColumns columns = listView.Header.Columns;
            Assert.AreEqual(3, columns.Count);
            Assert.AreEqual("Key", columns[1].Name);
            Assert.AreEqual("Value", columns[2].Name);
        }

        [Test]
        public void RowCount()
        {
            Assert.AreEqual(6, listView.Rows.Count);
        }

        [Test]
        public void CellCount()
        {
            ListViewRow row = listView.Rows[0];
            Assert.AreEqual(2, row.Cells.Count);
        }

        [Test]
        public void CellText()
        {
            ListViewRow first = listView.Rows[0];
            Assert.AreEqual("Search", first.Cells[0].Text);
            Assert.AreEqual("Google", first.Cells[1].Text);
            ListViewRow second = listView.Rows[1];
            Assert.AreEqual("Mail", second.Cells[0].Text);
            Assert.AreEqual("GMail", second.Cells[1].Text);
        }

        [Test]
        public void SelectedRows()
        {
            listView.Rows[5].Select();
            listView.Rows[0].Select();
            ListViewRows rows = listView.SelectedRows;
            Assert.AreEqual(1, rows.Count);
        }

        [Test]
        public void MultiSelect()
        {
            listView.Rows[0].Select();
            listView.Rows[1].MultiSelect();
            Assert.AreEqual(2, listView.SelectedRows.Count);
        }

        [Test, Ignore("Needs list view to select full row, which break other listview test")]
        public void FindModalWindowAppearingOnDoubleClick()
        {
            ListViewRows rows = listView.Rows;
            rows[0].DoubleClick();
            CloseModal(window);
        }
    }
}