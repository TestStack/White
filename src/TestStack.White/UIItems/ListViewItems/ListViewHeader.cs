using System.Collections.Generic;
using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.UIItems.Actions;

namespace TestStack.White.UIItems.ListViewItems
{
    public class ListViewHeader : UIItem
    {
        private readonly AutomationElementFinder automationElementFinder;

        protected ListViewHeader() {}

        public ListViewHeader(AutomationElement automationElement, IActionListener actionListener) : base(automationElement, actionListener)
        {
            automationElementFinder = new AutomationElementFinder(automationElement);
        }

        public virtual ListViewColumns Columns
        {
            get
            {
                List<AutomationElement> collection = automationElementFinder.Children(AutomationSearchCondition.ByControlType(ControlType.HeaderItem));
                return new ListViewColumns(collection, actionListener);
            }
        }

        public virtual ListViewColumn Column(string text)
        {
            return Columns.Find(column => column.Text == text);
        }
    }
}