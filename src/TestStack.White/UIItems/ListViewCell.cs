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
            //The reason is selected is using the HasKeyboardFocus property instead of a selection item pattern is because the cells do not support the selection item pattern.
            //If this ever changes this should be switched to use the selection item pattern.
            get { return cell.Current.HasKeyboardFocus; }
        }
    }
}