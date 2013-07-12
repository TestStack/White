using System.Collections.Generic;
using System.Windows.Automation;
using TestStack.White.Factory;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.UIItems.ListViewItems
{
    public class ListViewColumns : UIItemList<ListViewColumn>
    {
        public ListViewColumns(List<AutomationElement> automationElementCollection, ActionListener actionListener)
        {
            int i = 0;
            foreach (AutomationElement element in automationElementCollection)
                Add(new ListViewColumn(element, actionListener, i++));
        }

        public virtual ListViewColumn this[string text]
        {
            get
            {
                ListViewColumn column = Find(delegate(ListViewColumn obj) { return obj.Name.Equals(text); });
                if (column == null) throw new UIItemSearchException("Cannot find column with text " + text);
                return column;
            }
        }
    }
}