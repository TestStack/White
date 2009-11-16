using System.Windows.Automation;

namespace White.Core.AutomationElementSearch.Properties
{
    public class ControlTypeProperty : AutomationElementProperty
    {
        public virtual bool HasValue(AutomationElement.AutomationElementInformation information, object value)
        {
            return information.ControlType.Id.Equals(value);
        }
    }
}