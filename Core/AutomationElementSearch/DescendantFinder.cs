using System.Collections.Generic;
using System.Windows.Automation;
using System.Linq;

namespace White.Core.AutomationElementSearch
{
    public class DescendantFinder : IDescendantFinder
    {
        private readonly AutomationElement automationElement;

        public DescendantFinder(AutomationElement automationElement)
        {
            this.automationElement = automationElement;
        }

        public virtual AutomationElement Descendant(AutomationSearchCondition automationSearchCondition)
        {
            return Descendant(automationSearchCondition.Condition);
        }

        public virtual AutomationElement Descendant(Condition condition)
        {
            return automationElement.FindFirst(TreeScope.Descendants, condition);
        }

        public virtual List<AutomationElement> Descendants(AutomationSearchCondition automationSearchCondition)
        {
            AutomationElementCollection collection = automationElement.FindAll(TreeScope.Descendants, automationSearchCondition.Condition);
            var enumerable = collection.Cast<AutomationElement>();
            return new List<AutomationElement>(enumerable);
        }
    }
}