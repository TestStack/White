using System.Collections.Generic;
using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.Configuration;

namespace TestStack.White.UIItems.PropertyGridItems
{
    public class PropertyGridElementFinder
    {
        private readonly AutomationElementFinder finder;

        public PropertyGridElementFinder(AutomationElement automationElement)
        {
            finder = new AutomationElementFinder(automationElement);
        }

        public virtual List<AutomationElement> FindRows()
        {
            return finder.Children(AutomationSearchCondition.ByControlType(ControlType.Table),
                                   AutomationSearchCondition.ByControlType(ControlType.Custom));
        }

        public virtual AutomationElement FindBrowseButton()
        {
            AutomationElement element = finder.Child(AutomationSearchCondition.ByControlType(ControlType.Table),
                                                     AutomationSearchCondition.ByControlType(ControlType.Button).WithName("Browse..."));
            return element;
        }
    }
}