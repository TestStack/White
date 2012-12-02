using System.Windows.Automation;
using White.Core.UIItems;
using White.Core.UIItems.Actions;
using White.Core.UIItems.TableItems;

namespace White.Core.Factory
{
    public class TableHeaderFactory : UIItemFactory
    {
        public virtual IUIItem Create(AutomationElement automationElement, ActionListener actionListener)
        {
            return new TableHeader(automationElement, actionListener);
        }
    }
}