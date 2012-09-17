using System;
using System.Collections.Generic;
using System.Windows.Automation;
using White.Core.AutomationElementSearch;
using White.Core.Factory;
using White.Core.Mappings;
using White.Core.UIItems;
using White.Core.UIItems.Actions;
using White.Core.UIItems.Finders;

namespace White.Core.Finder
{
    public class CachedUIItems
    {
        private readonly List<AutomationElement> list = new List<AutomationElement>();
        private readonly DictionaryMappedItemFactory dictionaryMappedItemFactory = new DictionaryMappedItemFactory();
        private UIItemCollection uiItemCollection;
        private CachedUIItems() {}

        public static CachedUIItems CreateAndCachePrimaryChildControls(AutomationElement parent, InitializeOption option)
        {
            var cachedUIItems = new CachedUIItems();
            cachedUIItems.FindAll(parent, option);
            cachedUIItems.list.Sort(new AutomationElementPositionComparer());
            return cachedUIItems;
        }

        private void FindAll(AutomationElement automationElement, InitializeOption option)
        {
            var finder = new AutomationElementFinder(automationElement);
            List<AutomationElement> children = finder.Children(AutomationSearchCondition.All);
            ControlDictionary controlDictionary = ControlDictionary.Instance;
            foreach (AutomationElement child in children)
            {
                if (!controlDictionary.IsControlTypeSupported(child.Current.ControlType)) continue;
                if (controlDictionary.IsPrimaryControl(child.Current.ControlType, child.Current.ClassName, null)) list.Add(child);
                if (!controlDictionary.HasPrimaryChildren(child.Current.ControlType)) continue;
                if (!controlDictionary.IsExcluded(child.Current.ControlType)) FindAll(child, option);
            }
        }

        public virtual UIItemCollection GetAll(Predicate<AutomationElement> predicate, UIItemFactory factory, ActionListener actionListener)
        {
            List<AutomationElement> foundElements = list.FindAll(predicate);
            return new UIItemCollection(foundElements, factory, actionListener);
        }

        public virtual UIItemCollection UIItems(ActionListener actionListener)
        {
            if (uiItemCollection != null) return uiItemCollection;
            uiItemCollection = new UIItemCollection();
            foreach (AutomationElement automationElement in list)
                uiItemCollection.Add(dictionaryMappedItemFactory.Create(automationElement, actionListener));
            return uiItemCollection;
        }

        public virtual int Count
        {
            get { return list.Count; }
        }

        public virtual IUIItem Get(SearchCriteria searchCriteria, ActionListener actionListener)
        {
            return Get(searchCriteria, actionListener, dictionaryMappedItemFactory);
        }

        public virtual UIItemCollection GetAll(SearchCriteria searchCriteria, ActionListener actionListener)
        {
            return GetAll(searchCriteria, actionListener, dictionaryMappedItemFactory);
        }

        public virtual IUIItem Get(SearchCriteria searchCriteria, ActionListener actionListener, UIItemFactory factory)
        {
            List<AutomationElement> automationElements = searchCriteria.Filter(list);
            if (automationElements.Count == 0) return null;
            return factory.Create(automationElements[0], actionListener);
        }

        public virtual T Get<T>(SearchCriteria searchCriteria, ActionListener actionListener) where T : UIItem
        {
            return Get<T>(searchCriteria, actionListener, dictionaryMappedItemFactory);
        }

        public virtual T Get<T>(SearchCriteria searchCriteria, ActionListener actionListener, UIItemFactory factory) where T : UIItem
        {
            return (T) Get(searchCriteria.AndControlType(typeof (T)), actionListener, factory);
        }

        private UIItemCollection GetAll(SearchCriteria searchCriteria, ActionListener actionListener, UIItemFactory factory)
        {
            List<AutomationElement> automationElements = searchCriteria.Filter(list);
            return new UIItemCollection(automationElements.ToArray(), factory, actionListener);
        }
    }
}