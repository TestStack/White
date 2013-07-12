using System.Windows.Automation;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.UIItems
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