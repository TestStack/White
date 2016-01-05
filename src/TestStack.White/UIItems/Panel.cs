using System.Windows.Automation;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.UIItems
{
    /// <summary>
    /// Represents ControlType.Pane object. Child UIItems can be found from it.
    /// </summary>
    public class Panel : UIItemContainer
    {
        protected Panel() {}
        public Panel(AutomationElement automationElement, IActionListener actionListener) : base(automationElement, actionListener) {}

        public virtual string Text
        {
            get { return Name; }
        }
    }
}