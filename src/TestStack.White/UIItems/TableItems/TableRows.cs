using System.Collections;
using System.Windows.Automation;
using TestStack.White.Factory;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.UIItems.TableItems
{
    public class TableRows : UIItemList<TableRow>
    {
        protected TableRows() {}
        public TableRows(ICollection tees) : base(tees) {}

        public TableRows(ICollection rowElements, ActionListener actionListener, TableHeader tableHeader, TableCellFactory tableCellFactory)
        {
            foreach (AutomationElement automationElement in rowElements)
                Add(new TableRow(automationElement, actionListener, tableHeader, tableCellFactory));
        }

        public virtual TableRow Get(string column, string value)
        {
            return Find(obj => obj.Cells[column].Value.Equals(value));
        }

        /// <summary>
        /// Returns multiple rows containing the value for specified column.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual TableRows GetMultipleRows(string column, string value)
        {
            return new TableRows(FindAll(obj => obj.Cells[column].Value.Equals(value)));
        }
    }
}