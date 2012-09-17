using System.Collections.Generic;
using System.Windows;
using System.Windows.Automation;
using White.Core.AutomationElementSearch;
using White.Core.Configuration;
using White.Core.UIItems;
using White.Core.UIItems.Actions;
using White.Core.UIItems.Finders;
using White.Core.UIItems.MenuItems;
using White.Core.UIItems.WindowItems;
using White.Core.Utility;

namespace White.Core.Factory
{
    public class PrimaryUIItemFactory : ChildWindowFactory
    {
        private readonly DictionaryMappedItemFactory dictionaryMappedItemFactory = new DictionaryMappedItemFactory();

        public PrimaryUIItemFactory(AutomationElementFinder finder) : base(finder) {}

        public virtual ToolTip ToolTip
        {
            get
            {
                return ToolTipFinder.FindToolTip(() => finder.Child(AutomationSearchCondition.ByControlType(ControlType.ToolTip)));
            }
        }

        public virtual TitleBar GetTitleBar(ActionListener actionListener)
        {
            AutomationElement titleElement = finder.Child(AutomationSearchCondition.ByControlType(ControlType.TitleBar));
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
            var element = Retry.For(() => finder.Child(searchConditions),
                                      CoreAppXmlConfiguration.Instance.PopupTimeout, 100);
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
            return dictionaryMappedItemFactory.Create(finder.Descendant(searchCriteria.AutomationCondition), actionListener,
                                                      searchCriteria.CustomItemType);
        }

        public virtual UIItemCollection CreateAll(SearchCriteria searchCriteria, ActionListener actionListener)
        {
            return new UIItemCollection(finder.Descendants(searchCriteria.AutomationSearchCondition), actionListener, searchCriteria.CustomItemType);
        }

        public virtual Image WinFormImage(string primaryIdentification, ActionListener actionListener)
        {
            AutomationElement element = finder.Descendant(SearchCriteria.ByAutomationId(primaryIdentification).AutomationCondition);
            return new Image(element, actionListener);
        }

        public virtual UIItemCollection ItemsWithin(Rect bounds, ActionListener actionListener)
        {
            var collection = new UIItemCollection();
            List<AutomationElement> descendants = finder.Descendants(AutomationSearchCondition.All);
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