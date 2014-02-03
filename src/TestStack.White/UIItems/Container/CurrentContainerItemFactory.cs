using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;
using TestStack.White.Factory;
using TestStack.White.Finder;
using TestStack.White.Mappings;
using TestStack.White.Sessions;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Finders;

namespace TestStack.White.UIItems.Container
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
                    .GetAll(SearchCriteria.ByControlType(ct), automationElement.Current.FrameworkId)
                    .OfType<T>())
                .ToList();
        }

        public virtual UIItemCollection FindAll()
        {
            return current.GetAll(SearchCriteria.All, automationElement.Current.FrameworkId);
        }

        public virtual UIItemCollection FindAll(SearchCriteria criteria)
        {
            return current.GetAll(criteria, automationElement.Current.FrameworkId);
        }
    }
}