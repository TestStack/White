using System.Windows.Automation;

namespace White.Core.AutomationElementSearch.Properties
{
    public class ClassNameProperty : AutomationElementProperty
    {
        public virtual bool HasValue(AutomationElement.AutomationElementInformation information, object value)
        {
            return information.ClassName.Equals(value);
        }
    }
}