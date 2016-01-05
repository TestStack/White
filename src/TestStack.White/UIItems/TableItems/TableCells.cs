using System.Collections;
using System.Windows.Automation;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.UIItems.TableItems
{
    public class TableCells : UIItemList<TableCell>
    {
        private readonly TableHeader tableHeader;

        public TableCells(ICollection tableCellElements, TableHeader tableHeader, IActionListener actionListener)
        {
            this.tableHeader = tableHeader;
            foreach (AutomationElement tableCellElement in tableCellElements)
                Add(new TableCell(tableCellElement, actionListener));
        }

        public virtual TableCell this[string column]
        {
            get
            {
                if (tableHeader == null && string.IsNullOrEmpty(column)) return this[0];
                if (tableHeader == null) throw new UIActionException(string.Format("Cannot get cell for {0}", column));
                return this[tableHeader.Columns[column].Index];
            }
        }
    }
}