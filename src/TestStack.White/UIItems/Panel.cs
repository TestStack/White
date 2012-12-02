using System.Windows.Automation;
using White.Core.UIItems.Actions;

namespace White.Core.UIItems
{
    /// <summary>
    /// Represents ControlType.Pane object. Child UIItems can be found from it.
    /// </summary>
    public class Panel : UIItemContainer
    {
        protected Panel() {}
        public Panel(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}

        public virtual string Text
        {
            get { return Name; }
        }
    }
}