using System.Windows.Automation;
using White.Core.UIItems.Actions;

namespace White.Core.UIItems
{
    public class WPFButton : Button
    {
        protected WPFButton()
        {
        }

        public WPFButton(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener)
        {
        }
    }
}