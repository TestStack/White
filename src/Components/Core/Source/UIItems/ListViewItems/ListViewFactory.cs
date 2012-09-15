using System.Windows.Automation;
using White.Core.AutomationElementSearch;
using White.Core.UIItems.Actions;

namespace White.Core.UIItems.ListViewItems
{
    public class ListViewFactory
    {
        private readonly AutomationElementFinder automationElementFinder;
        private readonly ActionListener actionListener;

        public ListViewFactory(AutomationElementFinder automationElementFinder, ActionListener actionListener)
        {
            this.automationElementFinder = automationElementFinder;
            this.actionListener = actionListener;
        }

        public virtual ListViewRows Rows
        {
            get { return new ListViewRows(automationElementFinder, actionListener, Header); }
        }

        public virtual ListViewHeader Header
        {
            get
            {
                AutomationElement element = automationElementFinder.Child(AutomationSearchCondition.ByControlType(ControlType.Header));
                if (element == null) return null;
                return new ListViewHeader(element, actionListener);
            }
        }
    }
}