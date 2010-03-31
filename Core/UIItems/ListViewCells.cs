using System.Collections.Generic;
using System.Windows.Automation;
using Bricks.Core;
using White.Core.Factory;
using White.Core.UIItems.Actions;
using White.Core.UIItems.ListViewItems;

namespace White.Core.UIItems
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
                if (header == null && S.IsEmpty(columnName)) return this[0];
                if (header == null) throw new UIActionException("Cannot get cell for " + columnName);
                return this[header.Column(columnName)];
            }
        }

        internal virtual ListViewCell this[ListViewColumn column]
        {
            get
            {
                var span = new HorizontalSpan(column.Bounds);
                return Find(cell => !span.IsOutside(cell.Bounds));
            }
        }
    }
}