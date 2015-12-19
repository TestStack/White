using NUnit.Framework;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListViewItems;

namespace TestStack.White.UITests.ControlTests.ListControls
{
    [TestFixture(WindowsFramework.WinForms)]
    [TestFixture(WindowsFramework.Wpf)]
    public class ListViewTests : WhiteUITestBase
    {
        public ListViewTests(WindowsFramework framework)
            : base(framework)
        {
        }

        [Test]
        public void SelectRowTest()
        {
            using (var window = StartScenario("OpenListView", "ListViewWindow"))
            {
                var listView = window.Get<ListView>("ListView");
                listView.Select(0);
                var firstRow = listView.Rows[0];
                Assert.That( firstRow.IsSelected, Is.True);
                Assert.That(listView.HelpText, Is.EqualTo("ListView item selected - " + 0));
                listView.Select(1);
                var secondRow = listView.Rows[1];
                Assert.That( secondRow.IsSelected, Is.True);
            }
        }

        [Test]
        public void SelectScrolledRowTest()
        {
            using (var window = StartScenario("OpenListView", "ListViewWindow"))
            {
                var listView = window.Get<ListView>("ListView");
                listView.Select("Key", "Action15");
                Assert.That(listView.SelectedRows[0].Cells["Value"].Text, Is.EqualTo("App15"));
            }
        }

        [Test]
        public void SelectedRowTest()
        {
            using (var window = StartScenario("OpenListView", "ListViewWindow"))
            {
                var listView = window.Get<ListView>("ListView");
                listView.Select(0);
                var listViewRow = listView.SelectedRows[0];
                Assert.That(listViewRow.Cells["Key"].Text, Is.EqualTo("Search"));
            }
        }

        [Test]
        public void SelectBasedOnCellTest()
        {
            using (var window = StartScenario("OpenListView", "ListViewWindow"))
            {
                var listView = window.Get<ListView>("ListView");
                listView.Select("Key", "Mail");
                Assert.That(listView.SelectedRows[0].Cells["Key"].Text, Is.EqualTo("Mail"));
            }
        }

        [Test]
        public void ColumnsTest()
        {
            using (var window = StartScenario("OpenListView", "ListViewWindow"))
            {
                var listView = window.Get<ListView>("ListView");
                var columns = listView.Header.Columns;
                Assert.That(columns.Count, Is.EqualTo(2));
                Assert.That(columns[0].Name, Is.EqualTo("Key"));
                Assert.That(columns[1].Name, Is.EqualTo("Value"));
            }
        }
        [Test]
        public void RowCountTest()
        {
            using (var window = StartScenario("OpenListView", "ListViewWindow"))
            {
                var listView = window.Get<ListView>("ListView");
                Assert.That(listView.Rows.Count, Is.EqualTo(18));
            }
        }

        [Test]
        public void CellCountTest()
        {
            using (var window = StartScenario("OpenListView", "ListViewWindow"))
            {
                var listView = window.Get<ListView>("ListView");
                var row = listView.Rows[0];
                Assert.That(row.Cells.Count, Is.EqualTo(2));
            }
        }

        [Test]
        public void CellTextTest()
        {
            using (var window = StartScenario("OpenListView", "ListViewWindow"))
            {
                var listView = window.Get<ListView>("ListView");
                var first = listView.Rows[0];
                Assert.That(first.Cells[0].Text, Is.EqualTo("Search"));
                Assert.That(first.Cells[1].Text, Is.EqualTo("Google"));
                var second = listView.Rows[1];
                Assert.That(second.Cells[0].Text, Is.EqualTo("Mail"));
                Assert.That(second.Cells[1].Text, Is.EqualTo("GMail"));
            }
        }

        [Test]
        public void SelectedRowsTest()
        {
            using (var window = StartScenario("OpenListView", "ListViewWindow"))
            {
                var listView = window.Get<ListView>("ListView");
                listView.Rows[2].Select();
                listView.Rows[0].Select();
                var rows = listView.SelectedRows;
                Assert.That(rows.Count, Is.EqualTo(1));
            }
        }

        [Test]
        public void MultiSelectTest()
        {
            using (var window = StartScenario("OpenListView", "ListViewWindow"))
            {
                var listView = window.Get<ListView>("ListView");
                listView.Rows[0].Select();
                listView.Rows[1].MultiSelect();
                Assert.That(listView.SelectedRows.Count, Is.EqualTo(2));
            }
        }

        [Test]
        public void SelectWhenHorizontalScrollIsPresentTest()
        {
            using (var window = StartScenario("OpenListView", "ListViewWindow"))
            {
                var listView = window.Get<ListView>("ListViewWithHorizontalScroll");
                listView.Row("Key", "bardfgreerrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrre")
                    .Select();
            }
        }
    }
}