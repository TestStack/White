using System.Windows.Automation;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.UIItems.TableItems
{
    public class TableRowHeader : UIItem
    {
        protected TableRowHeader() {}
        public TableRowHeader(AutomationElement automationElement, IActionListener actionListener) : base(automationElement, actionListener) {}
    }
}