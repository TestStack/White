using System.Collections.Generic;
using System.Windows.Automation;

namespace TestStack.White.AutomationElementSearch
{
    public interface IDescendantFinder
    {
        AutomationElement Descendant(AutomationSearchCondition automationSearchCondition);
        AutomationElement Descendant(Condition condition);
        List<AutomationElement> Descendants(AutomationSearchCondition automationSearchCondition);
    }
}