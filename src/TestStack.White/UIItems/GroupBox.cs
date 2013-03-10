using System.Windows.Automation;
using White.Core.UIItems.Actions;

namespace White.Core.UIItems
{
    public class GroupBox : UIItemContainer, IMappableUIItem
    {
        protected GroupBox() {}
        public GroupBox(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}
    }
}