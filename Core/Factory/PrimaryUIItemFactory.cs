using System.Windows;
using System.Windows.Automation;
using Bricks.Core;
using White.Core.AutomationElementSearch;
using White.Core.Configuration;
using White.Core.UIItems;
using White.Core.UIItems.Actions;
using White.Core.UIItems.Finders;
using White.Core.UIItems.MenuItems;
using White.Core.UIItems.WindowItems;

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
                Clock.Do perform = () => finder.Child(AutomationSearchCondition.ByControlType(ControlType.ToolTip));
                return ToolTipFinder.FindToolTip(perform);
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
            var clock = new Clock(CoreAppXmlConfiguration.Instance.PopupTimeout, 100);
            Clock.Do @do = () => finder.Child(searchConditions);
            Clock.Matched matched = obj => obj != null;
            var element = (AutomationElement) clock.Perform(@do, matched, () => null);
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
            return new UIItemCollection(finder.Descendants(searchCriteria.AutomationCondition), actionListener, searchCriteria.CustomItemType);
        }

        public virtual Image WinFormImage(string primaryIdentification, ActionListener actionListener)
        {
            AutomationElement element = finder.Descendant(SearchCriteria.ByAutomationId(primaryIdentification).AutomationCondition);
            return new Image(element, actionListener);
        }

        public virtual UIItemCollection ItemsWithin(Rect bounds, ActionListener actionListener)
        {
            var collection = new UIItemCollection();
            AutomationElementCollection descendants = finder.Descendants(AutomationSearchCondition.All);
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