using System.Collections.Generic;
using System.Windows.Automation;
using TestStack.White.Factory;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.ListViewItems;

namespace TestStack.White.UIItems
{
    public class ListViewCells : UIItemList<ListViewCell>
    {
        private readonly ListViewHeader header;

        public ListViewCells(List<AutomationElement> collection, ActionListener actionListener, ListViewHeader header)
            : base(collection, new ListViewCellFactory(), actionListener)
        {
            this.header = header;
        }

        public virtual ListViewCell this[string columnName]
        {
            get
            {
                if (header == null && string.IsNullOrEmpty(columnName)) return this[0];
                if (header == null) throw new UIActionException("Cannot get cell for " + columnName);
                return this[header.Column(columnName)];
            }
        }

        public virtual ListViewCell this[ListViewColumn column]
        {
            get
            {
                var span = new HorizontalSpan(column.Bounds);
                return Find(cell => !span.IsOutside(cell.Bounds));
            }
        }
    }
}