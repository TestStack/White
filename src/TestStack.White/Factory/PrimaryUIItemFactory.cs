using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.Configuration;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.Utility;

namespace TestStack.White.Factory
{
    public class PrimaryUIItemFactory : ChildWindowFactory
    {
        private readonly DictionaryMappedItemFactory dictionaryMappedItemFactory = new DictionaryMappedItemFactory();

        public PrimaryUIItemFactory(AutomationElementFinder finder) : base(finder) {}

        public virtual ToolTip ToolTip
        {
            get
            {
                return ToolTipFinder.FindToolTip(() => Finder.Descendant(AutomationSearchCondition.ByControlType(ControlType.ToolTip)), Finder.AutomationElement);
            }
        }

        public virtual TitleBar GetTitleBar(ActionListener actionListener)
        {
            AutomationElement titleElement = Finder.Child(AutomationSearchCondition.ByControlType(ControlType.TitleBar));
            if (titleElement == null) return null;
            return new TitleBar(titleElement, actionListener);
        }

        public virtual PopUpMenu WPFPopupMenu(ActionListener actionListener)
        {
            var searchConditions = new[]
                                       {
                                           AutomationSearchCondition.ByControlType(ControlType.Window),
                                           AutomationSearchCondition.ByControlType(ControlType.Menu)
                                       };
            PopUpMenu popUpMenu;
            TryGetPopupMenu(searchConditions, actionListener, out popUpMenu);
            return popUpMenu;
        }

        public virtual bool TryGetPopupMenu(ActionListener actionListener, out PopUpMenu popUpMenu)
        {
            var searchConditions = new[] {AutomationSearchCondition.ByControlType(ControlType.Menu).OfName("DropDown")};
            return TryGetPopupMenu(searchConditions, actionListener, out popUpMenu);
        }

        private bool TryGetPopupMenu(AutomationSearchCondition[] searchConditions, ActionListener actionListener, out PopUpMenu popUpMenu)
        {
            var element = Retry.For(() => Finder.Child(searchConditions), CoreAppXmlConfiguration.Instance.PopupTimeout(), TimeSpan.FromMilliseconds(100));
            if (element == null)
            {
                popUpMenu = null;
                return false;
            }
            popUpMenu = new PopUpMenu(element, actionListener);
            return true;
        }

        public virtual IUIItem Create(SearchCriteria searchCriteria, ActionListener actionListener)
        {
            if (searchCriteria.IsIndexed)
            {
                UIItemCollection collection = CreateAll(searchCriteria, actionListener);
                return searchCriteria.IndexedItem(collection);
            }
            return dictionaryMappedItemFactory.Create(Finder.Descendant(searchCriteria.AutomationCondition), actionListener,
                                                      searchCriteria.CustomItemType);
        }

        public virtual UIItemCollection CreateAll(SearchCriteria searchCriteria, ActionListener actionListener)
        {
            return new UIItemCollection(Finder.Descendants(searchCriteria.AutomationSearchCondition), actionListener, searchCriteria.CustomItemType);
        }

        public virtual Image WinFormImage(string primaryIdentification, ActionListener actionListener)
        {
            AutomationElement element = Finder.Descendant(SearchCriteria.ByAutomationId(primaryIdentification).AutomationCondition);
            return new Image(element, actionListener);
        }

        public virtual UIItemCollection ItemsWithin(Rect bounds, ActionListener actionListener)
        {
            var collection = new UIItemCollection();
            List<AutomationElement> descendants = Finder.Descendants(AutomationSearchCondition.All);
            foreach (AutomationElement automationElement in descendants)
            {
                if (!bounds.Contains(automationElement.Current.BoundingRectangle)) continue;

                var factory = new DictionaryMappedItemFactory();
                collection.Add(factory.Create(automationElement, actionListener));
            }
            return collection;
        }
    }
}