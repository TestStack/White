using System.Windows.Automation;
using White.Core.AutomationElementSearch.Properties;

namespace White.Core.AutomationElementSearch.Properties
{
    public class NameProperty : AutomationElementProperty
    {
        public virtual bool HasValue(AutomationElement.AutomationElementInformation information, object value)
        {
            return information.Name.Equals(value);
        }
    }
}