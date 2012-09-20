using System.Collections.Generic;
using System.Windows.Automation;
using White.Core.UIA;
using White.Core.UIItems.Actions;

namespace White.Core.UIItems.ListBoxItems
{
    public class ListItems : UIItemList<ListItem>, ListItemContainer
    {
        private readonly ActionListener actionListener;

        public ListItems(List<AutomationElement> collection, ActionListener actionListener) : base(collection, actionListener)
        {
            this.actionListener = actionListener;
        }

        public virtual ListItem SelectedItem
        {
            get { return Find(obj => obj.IsSelected); }
        }

        public virtual string SelectedItemText
        {
            get
            {
                ListItem item = SelectedItem;
                return item == null ? string.Empty : item.Text;
            }
        }

        public virtual ListItem Item(string text)
        {
            ListItem foundItem = ItemWithText(text);
            if (foundItem != null) return foundItem;

            MakeLastItemReadyForPerformingAction();

            foundItem = ItemWithText(text);
            if (foundItem != null) return foundItem;

            throw new UIActionException(string.Format("Item of text {0} not found.", text));
        }

        private void MakeLastItemReadyForPerformingAction()
        {
            if (Count == 0) return;
            ListItem lastItem = Item(Count - 1);
            if (lastItem.Bounds.IsZeroSize() || string.IsNullOrEmpty(lastItem.Text))
            {
                actionListener.ActionPerforming(lastItem);
            }
        }

        private ListItem ItemWithText(string text)
        {
            return Find(obj => obj.Text.Equals(text));
        }

        public virtual ListItem Item(int index)
        {
            return this[index];
        }

        public virtual void Select(string text)
        {
            Item(text).Select();
        }

        public virtual void Select(int index)
        {
            Item(index).Select();
        }
    }
}