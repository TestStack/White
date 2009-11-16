using System.Windows.Automation;
using White.Core.UIItems.Actions;
using White.Core.UIItems.Finders;

namespace White.Core.UIItems
{
    [PlatformSpecificItem]
    public class WPFLabel : Label
    {
        protected WPFLabel() {}
        public WPFLabel(AutomationElement automationElement, ActionListener actionListener) : base(automationElement, actionListener) {}

        public virtual Hyperlink Hyperlink(string text)
        {
            return (Hyperlink) factory.Create(SearchCriteria.ByText(text).AndControlType(typeof (Hyperlink)), actionListener);
        }
    }
}