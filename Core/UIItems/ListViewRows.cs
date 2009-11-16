using System.Collections;
using System.Windows.Automation;
using White.Core.AutomationElementSearch;
using White.Core.Factory;
using White.Core.UIItems.Actions;
using White.Core.UIItems.ListViewItems;

namespace White.Core.UIItems
{
    public class ListViewRows : UIItemList<ListViewRow>
    {
        private ListViewRows(ICollection tees) : base(tees) {}

        public ListViewRows(AutomationElementFinder finder, ActionListener actionListener, ListViewHeader header)
        {
            AutomationElementCollection collection = finder.Descendants(AutomationSearchCondition.ByControlType(ControlType.DataItem));
            foreach (AutomationElement element in collection)
                Add(new ListViewRow(element, actionListener, header));
        }

        public virtual ListViewRow Get(int zeroBasedIndex)
        {
            if (Count <= zeroBasedIndex) throw new UIItemSearchException("No row found with index " + zeroBasedIndex);
            return this[zeroBasedIndex];
        }

        public virtual ListViewRow Get(string column, string value)
        {
            return Find(obj => obj.Cells[column].Text.Equals(value));
        }

        public virtual ListViewRows SelectedRows
        {
            get { return new ListViewRows(FindAll(obj => obj.IsSelectedValue)); }
        }
    }
}