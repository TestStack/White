using System.Windows.Automation;
using White.Core.UIItems;
using White.Core.UIItems.Actions;

namespace White.Core.Factory
{
    public class ListViewCellFactory : UIItemFactory
    {
        public virtual IUIItem Create(AutomationElement automationElement, ActionListener actionListener)
        {
            return new ListViewCell(automationElement, actionListener);
        }
    }
}