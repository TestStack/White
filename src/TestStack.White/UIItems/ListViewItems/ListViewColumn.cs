using System.Windows.Automation;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.UIItems.ListViewItems
{
    public class ListViewColumn : UIItem
    {
        private readonly int index;
        public ListViewColumn() {}

        public ListViewColumn(AutomationElement automationElement, IActionListener actionListener, int index) : base(automationElement, actionListener)
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