using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.Configuration;
using TestStack.White.Factory;
using TestStack.White.SystemExtensions;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Finders;
using TestStack.White.Utility;

namespace TestStack.White.UIItems.MenuItems
{
    public class Menus : UIItemList<Menu>
    {
        static readonly DictionaryMappedItemFactory Factory = new DictionaryMappedItemFactory();

        public Menus(AutomationElement parent, IActionListener actionListener)
        {
            if (parent == null) throw new ArgumentNullException("parent", "You must specify a parent automation id when creating a menu");
            AutomationSearchCondition condition = AutomationSearchCondition.ByControlType(ControlType.MenuItem);
            var finder = new AutomationElementFinder(parent);
            finder = Retry.For(()=> PerformanceHackAsPopupMenuForWin32AppComesOnDesktop(finder, parent), CoreConfigurationLocator.Get().BusyTimeout.AsTimeSpan());
            List<AutomationElement> children = finder.Descendants(condition);
            foreach (AutomationElement child in children)
                Add((Menu) Factory.Create(child, actionListener));
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
                if (menuElement == null) throw new UIItemSearchException("Could not find Menu");
                finder = new AutomationElementFinder(menuElement);
            }
            return finder;
        }

        public virtual Menu Find(params string[] path)
        {
            return Find(path.Select(SearchCriteria.ByText).ToArray());
        }

        public virtual Menu Find(string text)
        {
            return Find(SearchCriteria.ByText(text));
        }

        public virtual Menu Find(SearchCriteria searchCriteria)
        {
            var find = Find(menuItem => searchCriteria.AppliesTo(menuItem.AutomationElement));

            Thread.Sleep(250); // We need to sleep here because windows animates menu items which makes the click close the menu instead of clicking on it

            return find;
        }

        public virtual Menu Find(params SearchCriteria[] path)
        {
            if (path.Length == 0) throw new ArgumentException("Menu path not specified");
            Menu item = Find(path[0]);
            if (item == null) throw new UIItemSearchException("Could not find Menu " + path[0]);
            if (path.Length == 1) return item;

            for (int i = 1; i < path.Length; i++)
            {
                item = item.SubMenu(path[i]);
                if (item == null) throw new UIItemSearchException("Could not find Menu " + path[i]);
            }

            return item;
        }
    }
}