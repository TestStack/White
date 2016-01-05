using System.Windows.Automation;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.TableItems;

namespace TestStack.White.Factory
{
    public class TableHeaderFactory : IUIItemFactory
    {
        public virtual IUIItem Create(AutomationElement automationElement, IActionListener actionListener)
        {
            return new TableHeader(automationElement, actionListener);
        }
    }
}