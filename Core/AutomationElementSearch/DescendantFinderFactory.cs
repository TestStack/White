using System.Windows.Automation;
using White.Core.Configuration;

namespace White.Core.AutomationElementSearch
{
    public class DescendantFinderFactory
    {
        public static IDescendantFinder Create(AutomationElement automationElement)
        {
            if (CoreAppXmlConfiguration.Instance.RawElementBasedSearch) return new RawAutomationElementFinder(automationElement);
            return new DescendantFinder(automationElement);
        }
    }
}