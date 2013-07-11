using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;
using White.Core.Factory;
using White.Core.Finder;
using White.Core.Mappings;
using White.Core.Sessions;
using White.Core.UIItems.Actions;
using White.Core.UIItems.Finders;

namespace White.Core.UIItems.Container
{
    public class CurrentContainerItemFactory
    {
        private readonly AutomationElement automationElement;
        private readonly ActionListener actionListener;
        private readonly ContainerItemFactory nonCachedContainerItemFactory;
        private ContainerItemFactory current;
        private ContainerItemFactory cachedContainerItemFactory;

        public CurrentContainerItemFactory(PrimaryUIItemFactory primaryUIItemFactory, InitializeOption initializeOption, AutomationElement automationElement,
                                           ActionListener listener)
        {
            this.automationElement = automationElement;
            actionListener = listener;
            current = nonCachedContainerItemFactory = new NonCachedContainerItemFactory(primaryUIItemFactory, actionListener);
            if (initializeOption.Cached)
            {
                cachedContainerItemFactory = CreateCacheFactory(initializeOption);
                current = cachedContainerItemFactory;
            }
        }

        private CachedContainerItemFactory CreateCacheFactory(InitializeOption option)
        {
            return new CachedContainerItemFactory(CachedUIItems.CreateAndCachePrimaryChildControls(automationElement, option), actionListener);
        }

        public virtual IUIItem Find(SearchCriteria searchCriteria, WindowSession windowSession)
        {
            return windowSession.Get(current, searchCriteria, actionListener);
        }

        public virtual void ReInitialize(InitializeOption option)
        {
            if (option.Cached) cachedContainerItemFactory = CreateCacheFactory(InitializeOption.NoCache);
            current = option.Cached ? cachedContainerItemFactory : nonCachedContainerItemFactory;
        }

        public virtual void Visit(WindowControlVisitor windowControlVisitor)
        {
            current.Visit(windowControlVisitor);
        }

        public virtual void ReloadIfCached()
        {
            if (current is CachedContainerItemFactory)
                current = CreateCacheFactory(InitializeOption.NoCache);
        }

        public virtual List<T> FindAll<T>()
        {
            return ControlDictionary.Instance
                .GetControlType(typeof (T), automationElement.Current.FrameworkId)
                .SelectMany(ct => current
                    .GetAll(SearchCriteria.ByControlType(ct))
                    .OfType<T>())
                .ToList();
        }

        public virtual UIItemCollection FindAll()
        {
            return current.GetAll(SearchCriteria.All);
        }

        public virtual UIItemCollection FindAll(SearchCriteria criteria)
        {
            return current.GetAll(criteria);
        }
    }
}