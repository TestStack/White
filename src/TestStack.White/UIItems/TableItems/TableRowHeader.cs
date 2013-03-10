using System.Windows.Automation;
using White.Core.UIItems.Actions;

namespace White.Core.UIItems.TableItems
{
    public class TableRowHeader : UIItem, IMappableUIItem
    {
        protected TableRowHeader() {}
        public TableRowHeader(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}
    }
}