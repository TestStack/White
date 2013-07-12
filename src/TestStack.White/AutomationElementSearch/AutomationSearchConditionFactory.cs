using System.Collections.Generic;
using System.Windows.Automation;

namespace TestStack.White.AutomationElementSearch
{
    public class AutomationSearchConditionFactory
    {
        public virtual List<AutomationSearchCondition> GetWindowSearchConditions(int processId)
        {
            return new List<AutomationSearchCondition>
                       {AutomationSearchCondition.GetWindowSearchCondition(processId, ControlType.Window), 
                        AutomationSearchCondition.GetWindowSearchCondition(processId, ControlType.Pane)};
        }
    }
}