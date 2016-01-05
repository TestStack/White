using System.Windows.Automation;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.Factory
{
    public class ListViewCellFactory : IUIItemFactory
    {
        public virtual IUIItem Create(AutomationElement automationElement, IActionListener actionListener)
        {
            return new ListViewCell(automationElement, actionListener);
        }
    }
}