using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;
using White.Core.AutomationElementSearch;
using White.Core.Recording;
using White.Core.UIItemEvents;
using White.Core.UIItems.Actions;
using White.Core.UIItems.ListViewItems;
using White.Core.UIItems.Scrolling;

namespace White.Core.UIItems
{
    //TODO Take care of horizontal scrolling
    /// <summary>
    /// Understands testing ListView in WinForm and WPF. Anything which is of ControlType=DataGrid. In order to test DataGridView in WinForm use
    /// Table class.
    /// A ListView consists of ListViewHeader and ListViewRows. ListViewHeader contains ListViewColumns. ListViewRows is collection of all the visible
    /// rows. A ListViewRow consists of ListViewCells.
    /// </summary>
    public class ListView : UIItem, SuggestionList, VerticalSpanProvider
    {
        private readonly ListViewFactory listViewFactory;
        private AutomationPropertyChangedEventHandler handler;

        protected ListView() {}

        public ListView(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener)
        {
            listViewFactory = new ListViewFactory(new AutomationElementFinder(automationElement), this);
        }

        /// <summary>
        /// Unselects previously selected row and selects this row. If this row is already selected it doesn't have any effect.
        /// </summary>
        /// <param name="zeroBasedRowIndex">Index of the row to select</param>
        public virtual void Select(int zeroBasedRowIndex)
        {
            Rows[zeroBasedRowIndex].Select();
        }

        /// <summary>
        /// Unselects previously selected row and selects this row. If this row is already selected it doesn't have any effect.
        /// </summary>
        /// <param name="zeroBasedRowIndex">Index of the row to select</param>
        public virtual void MultiSelect(int zeroBasedRowIndex)
        {
            Rows[zeroBasedRowIndex].MultiSelect();
        }

        /// <summary>
        /// Find the Cell in the ListView
        /// </summary>
        /// <param name="column">headertext of the column</param>
        /// <param name="zeroBasedRowIndex"></param>
        /// <returns></returns>
        public virtual ListViewCell Cell(string column, int zeroBasedRowIndex)
        {
            return Rows.Get(zeroBasedRowIndex).Cells[Header.Columns[column]];
        }

        /// <summary>
        /// Get all the available rows
        /// </summary>
        public virtual ListViewRows Rows
        {
            get { return listViewFactory.Rows; }
        }

        /// <summary>
        /// Get the listview header. This can be used to get column headers.
        /// </summary>
        public virtual ListViewHeader Header
        {
            get { return listViewFactory.Header; }
        }

        public virtual ListViewRows SelectedRows
        {
            get { return Rows.SelectedRows; }
        }

        /// <summary>
        /// Unselects previously selected row and selects this row. If this row is already selected it doesn't have any effect.
        /// Row is chosen based on the column name having value specified
        /// </summary>
        /// <param name="column">column header text</param>
        /// <param name="value">text of cell</param>
        public virtual void Select(string column, string value)
        {
            GetItem(column, value).Select();
        }

        private ListViewRow GetItem(string column, string value)
        {
            return Rows.Get(column, value);
        }

        /// <summary>
        /// Keeps the old row selected and selects this row. If this row is already selected it doesn't have any effect.
        /// Row is chosen based on the column name having value specified
        /// </summary>
        /// <param name="column">column header text</param>
        /// <param name="value">text of cell</param>
        public virtual void MultiSelect(string column, string value)
        {
            GetItem(column, value).MultiSelect();
        }

        public virtual ListViewRow Row(string column, string value)
        {
            return Rows.Get(column, value);
        }

        /// <summary>
        /// Try to un select all the rows. This would work when full row select in list view is false and there are atleast two columns
        /// </summary>
        public virtual void TryUnSelectAll()
        {
            ListViewRows rows = Rows;
            if (rows.Count == 0 || Header.Columns.Count < 2) return;

            rows[0].Cells[Header.Columns[1].Text].Click();
            ActionPerformed();
        }

        //TODO While recording you get exception when clicking at the corner of the cell
        public override void HookEvents(UIItemEventListener eventListener)
        {
            var safeAutomationEventHandler =
                new SafeAutomationEventHandler(this, eventListener, objs => ListViewEvent.Create(this, (AutomationPropertyChangedEventArgs) objs[0]));
            handler = safeAutomationEventHandler.PropertyChange;
            Automation.AddAutomationPropertyChangedEventHandler(automationElement, TreeScope.Descendants, handler, SelectionItemPattern.IsSelectedProperty);
        }

        public override void UnHookEvents()
        {
            Automation.RemoveAutomationPropertyChangedEventHandler(automationElement, handler);
        }

        public virtual List<string> Items
        {
            get
            {
                return Rows.Select(listViewRow => listViewRow.Cells[0].Text).ToList();
            }
        }

        public virtual void Select(string text)
        {
            ListViewRows rows = Rows;
            ListViewRow row = rows.Find(obj => obj.Cells[0].Text.Equals(text));
            if (row == null) throw new UIActionException("Could not find suggestion " + text);
            row.Select();
            SuggestionListView.WaitTillNotPresent();
            ActionPerformed();
        }

        public override void ActionPerforming(UIItem uiItem)
        {
            new ScreenItem(uiItem, ScrollBars).MakeVisible(this);
        }

        public virtual VerticalSpan VerticalSpan
        {
            get { return new VerticalSpan(Bounds).Minus(ScrollBars.Horizontal.Bounds); }
        }
    }
}
