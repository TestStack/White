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
            var element = finder.Child(AutomationSearchCondition.ByControlType(ControlType.Table),
                AutomationSearchCondition.ByControlType(ControlType.Button).OfName(UIItemIdAppXmlConfiguration.Instance.BrowseText));
            return element;
        }
    }
}