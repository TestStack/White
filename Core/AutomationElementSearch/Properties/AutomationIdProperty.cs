using System.Windows.Automation;

namespace White.Core.AutomationElementSearch.Properties
{
    public class AutomationIdProperty : AutomationElementProperty
    {
        public virtual bool HasValue(AutomationElement.AutomationElementInformation information, object value)
        {
            return information.AutomationId.Equals(value);
        }
    }
}