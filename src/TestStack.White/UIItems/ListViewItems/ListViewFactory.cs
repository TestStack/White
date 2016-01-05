using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.UIItems.ListViewItems
{
    public class ListViewFactory
    {
        private readonly AutomationElementFinder automationElementFinder;
        private readonly IActionListener actionListener;

        public ListViewFactory(AutomationElementFinder automationElementFinder, IActionListener actionListener)
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