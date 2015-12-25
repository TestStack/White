using System.Windows.Automation;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.UIItems
{
    public class ListViewCell : Label
    {
        private readonly AutomationElement cell;

        protected ListViewCell() {}

        public ListViewCell(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}

        public ListViewCell(AutomationElement automationElement, AutomationElement cell, ActionListener actionListener)
            : base(automationElement, actionListener)
        {
            this.cell = cell;
        }

        public bool IsSelected
        {
            get { return cell.Current.HasKeyboardFocus; }
        }
    }
}