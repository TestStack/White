using System.Windows.Automation;
using White.Core.UIItems.Actions;

namespace White.Core.UIItems.ListViewItems
{
    public class ListViewColumn : UIItem
    {
        private readonly int index;
        public ListViewColumn() {}

        public ListViewColumn(AutomationElement automationElement, ActionListener actionListener, int index) : base(automationElement, actionListener)
        {
            this.index = index;
        }

        public virtual int Index
        {
            get { return index; }
        }

        public virtual string Text
        {
            get { return Name; }
        }
    }
}