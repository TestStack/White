using System.Collections.Generic;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListViewItems;
using Xunit;

namespace TestStack.White.UITests.ControlTests.ListControls
{
    public class ListViewTest : WhiteTestBase
    {
        protected override void ExecuteTestRun(WindowsFramework framework)
        {
            RunTest(CellCount);
            RunTest(CellText);
            RunTest(Columns);
            RunTest(MultiSelect);
            RunTest(RowCount);
            RunTest(SelectBasedOnCell);
            RunTest(SelectRow);
            RunTest(SelectScrolledRow);
            RunTest(SelectedRow);
            RunTest(SelectedRows);
            RunTest(SelectWhenHorizontalScrollIsPresent);
            RunTest(CreateListViewRowDirectlyFromAutomationElement);
        }

        void SelectRow()
        {
            using (var window = StartScenario("OpenListView", "ListViewWindow"))
            {
                var listView = window.Get<ListView>("ListView");
                listView.Select(0);
                ListViewRow firstRow = listView.Rows[0];
                Assert.Equal(true, firstRow.IsSelected);
                Assert.Equal("ListView item selected - " + 0, listView.LegacyHelpText);
                listView.Select(1);
                ListViewRow secondRow = listView.Rows[1];
                Assert.Equal(true, secondRow.IsSelected);
            }
        }
        void SelectScrolledRow()
        {
            using (var window = StartScenario("OpenListView", "ListViewWindow"))
            {
                var listView = window.Get<ListView>("ListView");
                listView.Select("Key", "Action15");
                Assert.Equal("App15", listView.SelectedRows[0].Cells["Value"].Text);
            }
        }
        void CreateListViewRowDirectlyFromAutomationElement()
        {
            using (var window = StartScenario("OpenListView", "ListViewWindow"))
            {
                var listView = window.Get<ListView>("ListView");
                var factory = new DictionaryMappedItemFactory();
                var ae = listView.Rows[1].AutomationElement;
                var uiItem = factory.Create(ae, listView.ActionListener);
                Assert.IsAssignableFrom<ListViewRow>(uiItem);
            }
        }
        void SelectedRow()
        {
            using (var window = StartScenario("OpenListView", "ListViewWindow"))
            {
                var listView = window.Get<ListView>("ListView");
                listView.Select(0);
                ListViewRow listViewRow = listView.SelectedRows[0];
                Assert.Equal("Search", listViewRow.Cells["Key"].Text);
            }
        }

        void SelectBasedOnCell()
        {
            using (var window = StartScenario("OpenListView", "ListViewWindow"))
            {
                var listView = window.Get<ListView>("ListView");
                listView.Select("Key", "Mail");
                Assert.Equal("Mail", listView.SelectedRows[0].Cells["Key"].Text);
            }
        }

        void Columns()
        {
            using (var window = StartScenario("OpenListView", "ListViewWindow"))
            {
                var listView = window.Get<ListView>("ListView");
                ListViewColumns columns = listView.Header.Columns;
                Assert.Equal(2, columns.Count);
                Assert.Equal("Key", columns[0].Name);
                Assert.Equal("Value", columns[1].Name);
            }
        }

        void RowCount()
        {
            using (var window = StartScenario("OpenListView", "ListViewWindow"))
            {
                var listView = window.Get<ListView>("ListView");
                Assert.Equal(18, listView.Rows.Count);
            }
        }

        void CellCount()
        {
            using (var window = StartScenario("OpenListView", "ListViewWindow"))
            {
                var listView = window.Get<ListView>("ListView");
                ListViewRow row = listView.Rows[0];
                Assert.Equal(2, row.Cells.Count);
            }
        }

        void CellText()
        {
            using (var window = StartScenario("OpenListView", "ListViewWindow"))
            {
                var listView = window.Get<ListView>("ListView");
                ListViewRow first = listView.Rows[0];
                Assert.Equal("Search", first.Cells[0].Text);
                Assert.Equal("Google", first.Cells[1].Text);
                ListViewRow second = listView.Rows[1];
                Assert.Equal("Mail", second.Cells[0].Text);
                Assert.Equal("GMail", second.Cells[1].Text);
            }
        }

        void SelectedRows()
        {
            using (var window = StartScenario("OpenListView", "ListViewWindow"))
            {
                var listView = window.Get<ListView>("ListView");
                listView.Rows[2].Select();
                listView.Rows[0].Select();
                ListViewRows rows = listView.SelectedRows;
                Assert.Equal(1, rows.Count);
            }
        }

        void MultiSelect()
        {
            using (var window = StartScenario("OpenListView", "ListViewWindow"))
            {
                var listView = window.Get<ListView>("ListView");
                listView.Rows[0].Select();
                listView.Rows[1].MultiSelect();
                Assert.Equal(2, listView.SelectedRows.Count);
            }
        }

        void SelectWhenHorizontalScrollIsPresent()
        {
            using (var window = StartScenario("OpenListView", "ListViewWindow"))
            {
                var listView = window.Get<ListView>("ListViewWithHorizontalScroll");
                listView.Row("Key", "bardfgreerrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrre")
                    .Select();
            }
        }

        protected override IEnumerable<WindowsFramework> SupportedFrameworks()
        {
            yield return WindowsFramework.Wpf;
            yield return WindowsFramework.WinForms;
        }
    }
}