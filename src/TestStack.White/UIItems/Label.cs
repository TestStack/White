using System.Windows.Automation;
using White.Core.UIItems.Actions;

namespace White.Core.UIItems
{
    public class Label : UIItem
    {
        protected Label() {}
        public Label(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}

        public virtual string Text
        {
            get { return (string) Property(AutomationElement.NameProperty); }
        }
    }
}