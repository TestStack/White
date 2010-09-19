using System.Windows.Automation;
using White.Core.UIItems.Actions;

namespace White.Core.UIItems
{
    public class ListViewCell : Label
    {
        protected ListViewCell() {}
        public ListViewCell(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}
    }
}