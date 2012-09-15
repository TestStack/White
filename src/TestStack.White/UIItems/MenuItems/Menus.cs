using System;
using System.Collections.Generic;
using System.Windows.Automation;
using White.Core.AutomationElementSearch;
using White.Core.Factory;
using White.Core.UIItems.Actions;
using White.Core.UIItems.Finders;

namespace White.Core.UIItems.MenuItems
{
    public class Menus : UIItemList<Menu>
    {
        private static readonly DictionaryMappedItemFactory factory = new DictionaryMappedItemFactory();

        public Menus(AutomationElement parent, ActionListener actionListener)
        {
            AutomationSearchCondition condition = AutomationSearchCondition.ByControlType(ControlType.MenuItem);
            var finder = new AutomationElementFinder(parent);
            finder = PerformanceHackAsPopupMenuForWin32AppComesOnDesktop(finder, parent);
            List<AutomationElement> children = finder.Descendants(condition);
            foreach (AutomationElement child in children)
                Add((Menu) factory.Create(child, actionListener));
        }

        private static AutomationElementFinder PerformanceHackAsPopupMenuForWin32AppComesOnDesktop(AutomationElementFinder finder,
                                                                                                             AutomationElement parent)
        {
            if (parent.Equals(AutomationElement.RootElement))
            {
                AutomationElement menuElement = finder.Child(AutomationSearchCondition.ByControlType(ControlType.Menu));
                if (menuElement == null)
                {
                    AutomationElement windowElement = finder.Child(AutomationSearchCondition.ByControlType(ControlType.Window));
                    menuElement = new AutomationElementFinder(windowElement).Child(AutomationSearchCondition.ByControlType(ControlType.Menu));
                }
                finder = new AutomationElementFinder(menuElement);
            }
            return finder;
        }

        public virtual Menu Find(params string[] path)
        {
            var searchCriterias = new List<SearchCriteria>();
            foreach (string s in path)
            {
                searchCriterias.Add(SearchCriteria.ByText(s));
            }
            return Find(searchCriterias.ToArray());
        }

        public virtual Menu Find(string text)
        {
            return Find(SearchCriteria.ByText(text));
        }

        public virtual Menu Find(SearchCriteria searchCriteria)
        {
            return Find(menuItem => searchCriteria.AppliesTo(menuItem.AutomationElement));
        }

        public virtual Menu Find(params SearchCriteria[] path)
        {
            if (path.Length == 0) throw new ArgumentException("Menu path not specified");
            Menu item = Find(path[0]);
            if (item == null) throw new UIItemSearchException("Could not find Menu " + path[0]);
            for (int i = 1; i < path.Length; i++)
            {
                item.Click();
                item = item.SubMenu(path[i]);
                if (item == null) throw new UIItemSearchException("Could not find Menu " + path[i]);
            }
            return item;
        }
    }
}